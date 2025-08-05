﻿using System.Collections;
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

    private void Start()
    {
        _recipeViewManager = FindAnyObjectByType<RecipeViewManager>();
    }

    public void AddRecipe((RecipeData recipe, string name) recipe)
    {
        _recipes.Enqueue(recipe);
        _recipeViewManager.AddView(recipe);
    }

    public void CheckFood(string name)
    {
        if (_recipes.Peek().name == name)
        {
            _recipes.Dequeue();
            _recipeViewManager.RemoveView();
            return;
        }
    }

    public void RecipeCheck(List<string> foods)
    {
        if (_recipes.Count == 0)
        {
            Debug.Log("作るべきレシピがありません");
            return;
        }

        var currentRecipe = _recipes.Peek();
        if (ListsEqual(currentRecipe.recipe.Foods.ToList(), foods))
        {
            Debug.Log($"レシピ完成: {currentRecipe.name}");

            if (currentRecipe.recipe.FoodPrefab != null)
            {
                Instantiate(currentRecipe.recipe.FoodPrefab, _spawn.position, Quaternion.identity);
            }
            else
            {
                Debug.LogError($"料理 {currentRecipe.name} のプレハブが設定されていません");
            }
        }
        else
        {
            Debug.Log("レシピと材料が一致しません");
            Debug.Log($"必要な材料: [{string.Join(", ", currentRecipe.recipe.Foods)}]");
            Debug.Log($"投入した材料: [{string.Join(", ", foods)}]");
        }
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
