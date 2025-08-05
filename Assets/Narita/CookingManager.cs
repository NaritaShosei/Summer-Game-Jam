using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
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
            return;
        }
    }

    public void RecipeCheck(List<string> foods)
    {
        if (_recipes.Count == 0) { return; }
        if (ListsEqual(_recipes.Peek().recipe.Foods.ToList(), foods))
        {
            Debug.Log(_recipes.Peek().name);
            _recipes.Dequeue();
            _recipeViewManager.RemoveView();
            return;
        }
        Debug.Log("何もかもが違う");
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
