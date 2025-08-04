using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CookingData[] _cookingDatas;
    private Dictionary<List<KeyCode>, (RecipeData recipe, string name)> _cookingDictionary = new();
    private List<string> _baseNames = new();
    private List<string> _names = new();
    [SerializeField] private int _foodCount = 2;

    void Start()
    {
        foreach (var data in _cookingDatas)
        {
            if (IsCommandCheck(data.RecipeCommand.KeyList))
            {
                Debug.LogError($"{data.RecipeCommand}はすでに登録されています");
                continue;
            }
            _cookingDictionary.Add(data.RecipeCommand.KeyList, (data.RecipeData, data.FoodName));
            _baseNames.Add(data.FoodName);
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

        for (int i = 0; i < _foodCount; i++)
        {
            string name = _baseNames[Random.Range(0, _baseNames.Count)];
            while (_names.Contains(name))
            {
                name = _baseNames[Random.Range(0, _baseNames.Count)];
            }
            _names.Add(name);
        }
    }



    private bool IsCommandCheck(List<KeyCode> command)
    {
        foreach (var key in _cookingDictionary.Keys)
        {
            if (AreKeyListsEqual(key, command))
            {
                return true;
            }
        }
        return false;
    }
    private bool AreKeyListsEqual(List<KeyCode> a, List<KeyCode> b)
    {
        if (a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}