using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    [SerializeField] private Transform _spawn;
    private Queue<(RecipeData recipe, string name)> _recipes = new();
    public Queue<(RecipeData recipe, string name)> Recipes => _recipes;
    private RecipeViewManager _recipeViewManager;
    private OrderManager _orderManager;
    [SerializeField] private GameObject _yami;

    private void Start()
    {
        _recipeViewManager = FindAnyObjectByType<RecipeViewManager>();
        _orderManager = FindAnyObjectByType<OrderManager>();
    }

    public void AddRecipe((RecipeData recipe, string name) recipe)
    {
        _recipes.Enqueue(recipe);
        _recipeViewManager.UpdateViews(_recipes);
    }

    public void CheckFood(string name)
    {
        if (_recipes.Count == 0) { return; }
        if (_recipes.Peek().name == name)
        {
            _recipes.Dequeue();
            _recipeViewManager.UpdateViews(_recipes);
            return;
        }
    }

    public void RecipeCheck(List<string> foods, CookingMethod method)
    {
        foreach (var recipe in _orderManager.CookingDictionary.Values)
        {
            if (ListsEqual(recipe.recipe.Foods.ToList(), foods) && recipe.recipe.CookingMethod == method)
            {
                Debug.Log($"レシピ完成: {recipe.name}");

                if (recipe.recipe.FoodPrefab != null)
                {
                    Instantiate(recipe.recipe.FoodPrefab, _spawn.position, Quaternion.Euler(90, 0, 0));
                    return;
                }
                else
                {
                    Debug.LogError($"料理 {recipe.name} のプレハブが設定されていません");
                }
            }
            else
            {
                Debug.Log("レシピと材料が一致しません");
                Debug.Log($"必要な材料: [{string.Join(", ", recipe.recipe.Foods)}]");
                Debug.Log($"投入した材料: [{string.Join(", ", foods)}]");
            }
        }
        Instantiate(_yami, _spawn.position, Quaternion.Euler(90, 0, 0));
    }
    private bool ListsEqual(List<string> a, List<string> b)
    {
        a = a.Select(x => x.Trim().ToLower()).OrderBy(x => x).ToList();
        b = b.Select(x => x.Trim().ToLower()).OrderBy(x => x).ToList();

        if (a.Count != b.Count) return false;
        for (int i = 0; i < a.Count; i++)
        {
            if (a[i] != b[i]) return false;
        }
        return true;
    }
}
