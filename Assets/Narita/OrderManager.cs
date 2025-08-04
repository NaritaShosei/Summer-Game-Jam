using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    [SerializeField] private CookingData[] _cookingDatas;
    private Dictionary<List<Arrow>, (RecipeData recipe, string name)> _cookingDictionary = new();
    private List<List<Arrow>> _baseKeys = new();
    private List<List<Arrow>> _keys = new();
    [SerializeField] private int _foodCount = 2;
    private RecipeData _recipe;
    private string _name;
    [SerializeField] private CookingManager _cookingManager;

    public (RecipeData recipe, string name) Food => (_recipe, _name);

    void Start()
    {
        _cookingManager = FindAnyObjectByType<CookingManager>();

        foreach (var data in _cookingDatas)
        {
            if (IsCommandCheck(_cookingDictionary.Keys.ToList(), data.RecipeCommand.KeyList))
            {
                Debug.LogError($"{data.RecipeCommand}はすでに登録されています");
                continue;
            }
            _cookingDictionary.Add(data.RecipeCommand.KeyList, (data.RecipeData, data.FoodName));
            _baseKeys.Add(data.RecipeCommand.KeyList);
        }

        // Debug用
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

        // 初期の料理名保存
        for (int i = 0; i < _foodCount; i++)
        {
            AddKey();
        }
    }

    private void Update()
    {
        if (_keys.Count < _foodCount)
        {
            AddKey();
        }
    }

    private void AddKey()
    {
        var unusedKeys = _baseKeys.Where(baseKey => !_keys.Any(k => AreKeyListsEqual(k, baseKey))).ToList();

        if (unusedKeys.Count == 0)
        {
            Debug.LogWarning("追加可能なキーがもうありません！");
            return;
        }

        var randomKey = unusedKeys[Random.Range(0, unusedKeys.Count)];
        _keys.Add(randomKey);
    }


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

    public void CommandEnter(List<Arrow> command)
    {
        foreach (var pair in _cookingDictionary)
        {
            if (AreKeyListsEqual(pair.Key, command))
            {
                _recipe = pair.Value.recipe;
                _name = pair.Value.name;

                StringBuilder sb = new();
                sb.Append($"料理名:{_name} ");
                foreach (var item in _recipe.Foods)
                {
                    sb.Append($"食材:{item} ");
                }
                sb.Append($"調理方法:{_recipe.CookingMethod}\n");
                Debug.Log(sb.ToString());
            }
        }
    }

    private bool AreKeyListsEqual(List<Arrow> a, List<Arrow> b)
    {
        if (a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}