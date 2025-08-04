using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CookingData[] _cookingDatas;
    // TODO:ここにコマンドのデータも追加する
    private Dictionary<string, RecipeData> _cookingDictionary = new();
    void Start()
    {
        foreach (var data in _cookingDatas)
        {
            if (_cookingDictionary.ContainsKey(data.FoodName))
            {
                Debug.LogError($"{data.FoodName}はすでに登録されています");
                continue;
            }
            _cookingDictionary.Add(data.FoodName, data.RecipeData);
        }
        StringBuilder sb = new();
        foreach (var data in _cookingDictionary)
        {
            sb.Append($"料理名:{data.Key} ");
            foreach (var item in data.Value.Foods)
            {
                sb.Append($"食材:{item} ");
            }
            sb.Append($"調理方法:{data.Value.CookingType}\n");
        }
        Debug.Log(sb.ToString());
    }

    void Update()
    {

    }
}
