using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// 料理の注文を管理するクラス
/// プレイヤーからのコマンド入力を受け取り、対応する料理のレシピを返す
/// </summary>
public class OrderManager : MonoBehaviour
{
    [SerializeField] private CookingData[] _cookingDatas; // Inspector上で設定する料理データの配列
    private Dictionary<List<Arrow>, (RecipeData recipe, string name)> _cookingDictionary = new(); // キー入力パターンと料理データのマッピング
    private List<List<Arrow>> _baseKeys = new(); // 登録されている全てのキー入力パターン
    private List<List<Arrow>> _keys = new(); // 現在利用可能なキー入力パターン
    [SerializeField] private int _foodCount = 2; // 同時に利用可能な料理の数
    private RecipeData _recipe; // 現在選択されているレシピデータ
    private string _name; // 現在選択されている料理名
    private CookingManager _cookingManager; // 料理管理システムへの参照

    /// <summary>
    /// 現在選択されている料理の情報を取得するプロパティ
    /// </summary>
    public (RecipeData recipe, string name) Food => (_recipe, _name);

    /// <summary>
    /// 現在利用可能なキー入力パターンを取得するプロパティ
    /// </summary>
    public List<List<Arrow>> Keys { get { return _keys; } }

    public Dictionary<List<Arrow>, (RecipeData recipe, string name)> CookingDictionary => _cookingDictionary;

    void Start()
    {
        // 料理管理システムを取得
        _cookingManager = FindAnyObjectByType<CookingManager>();

        // 料理データを辞書に登録
        foreach (var data in _cookingDatas)
        {
            // 重複チェック：同じキー入力パターンが既に登録されているかを確認
            if (IsCommandCheck(_cookingDictionary.Keys.ToList(), data.RecipeCommand.KeyList))
            {
                Debug.LogError($"{data.RecipeCommand}はすでに登録されています");
                continue;
            }
            // キー入力パターンと料理データをマッピング
            _cookingDictionary.Add(data.RecipeCommand.KeyList, (data.RecipeData, data.FoodName));
            // ベースとなるキー入力パターンを保存
            _baseKeys.Add(data.RecipeCommand.KeyList);
        }

        // Debug用：登録された料理情報をログ出力
        StringBuilder sb = new();
        foreach (var data in _cookingDictionary)
        {
            sb.Append($"料理名:{data.Value.name} ");
            foreach (var item in data.Value.recipe.Foods)
            {
                sb.Append($"食材:{item} ");
            }
            sb.Append($"調理方法:{data.Value.recipe.CookingMethod}\n");
        }
        Debug.Log(sb.ToString());

        // 初期状態で指定された数の料理キーを利用可能にする
        for (int i = 0; i < _foodCount; i++)
        {
            AddKey();
        }
    }

    private void Update()
    {
        // 利用可能なキーが指定数未満の場合、新しいキーを追加
        if (_keys.Count < _foodCount)
        {
            AddKey();
        }
    }

    /// <summary>
    /// 利用可能なキー入力パターンに新しいものを追加する
    /// </summary>
    private void AddKey()
    {
        // 現在利用可能でないキー入力パターンを取得
        var unusedKeys = _baseKeys.Where(baseKey => !_keys.Any(k => AreKeyListsEqual(k, baseKey))).ToList();

        // 追加可能なキーがない場合は警告を出して終了
        if (unusedKeys.Count == 0)
        {
            Debug.LogWarning("追加可能なキーがもうありません！");
            return;
        }

        // ランダムに1つのキーを選択して利用可能リストに追加
        var randomKey = unusedKeys[Random.Range(0, unusedKeys.Count)];
        _keys.Add(randomKey);
    }

    /// <summary>
    /// 指定されたコマンドが既に登録されているかをチェック
    /// </summary>
    /// <param name="keys">チェック対象のキーリスト</param>
    /// <param name="command">チェックするコマンド</param>
    /// <returns>既に存在する場合はtrue</returns>
    private bool IsCommandCheck(List<List<Arrow>> keys, List<Arrow> command)
    {
        foreach (var key in keys)
        {
            if (AreKeyListsEqual(key, command))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// プレイヤーからのコマンド入力を処理し、対応する料理を設定する
    /// </summary>
    /// <param name="command">入力されたコマンド</param>
    public void CommandEnter(List<Arrow> command)
    {
        foreach (var key in _keys)
        {
            //現在入力可能なコマンドとの比較
            if (AreKeyListsEqual(key, command))
            {
                var pair = _cookingDictionary[key];
                // 対応する料理が見つかった場合、レシピと名前を設定
                _recipe = pair.recipe;
                _name = pair.name;

                // 料理管理システムにレシピを追加
                _cookingManager.AddRecipe(Food);

                // Debug用：選択された料理情報をログ出力
                StringBuilder sb = new();
                sb.Append($"料理名:{_name} ");
                foreach (var item in _recipe.Foods)
                {
                    sb.Append($"食材:{item} ");
                }
                sb.Append($"調理方法:{_recipe.CookingMethod}\n");
                Debug.Log(sb.ToString());

                //選択されたコマンドに対応する料理を現在入力可能なリストから削除
                _keys.Remove(key);
                break;
            }
        }

        /*
        // 入力されたコマンドに対応する料理を辞書から検索
        foreach (var pair in _cookingDictionary)
        {
            if (AreKeyListsEqual(pair.Key, command))
            {
                // 対応する料理が見つかった場合、レシピと名前を設定
                _recipe = pair.Value.recipe;
                _name = pair.Value.name;

                // 料理管理システムにレシピを追加
                _cookingManager.AddRecipe(Food);

                // Debug用：選択された料理情報をログ出力
                StringBuilder sb = new();
                sb.Append($"料理名:{_name} ");
                foreach (var item in _recipe.Foods)
                {
                    sb.Append($"食材:{item} ");
                }
                sb.Append($"調理方法:{_recipe.CookingMethod}\n");
                Debug.Log(sb.ToString());
                break;
            }
        }*/
    }

    /// <summary>
    /// 2つのArrowリストが同じ内容かを比較する
    /// </summary>
    /// <param name="a">比較対象のリストA</param>
    /// <param name="b">比較対象のリストB</param>
    /// <returns>同じ内容の場合はtrue</returns>
    private bool AreKeyListsEqual(List<Arrow> a, List<Arrow> b)
    {
        // 要素数が違う場合は異なるリスト
        if (a.Count != b.Count) return false;
        // 各要素を順番に比較
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }

    /// <summary>
    /// コマンドに対応した料理の名前を取得する関数
    /// </summary>
    /// <param name="keys"> 取得したい料理のコマンド</param>
    /// <returns> 料理名</returns>
    public string GetFoodName(List<Arrow> keys)
    {
        foreach (var pair in _cookingDictionary)
        {
            if (AreKeyListsEqual(pair.Key, keys))
            {
                return _cookingDictionary[keys].name;
            }
        }
        return null;
    }
}