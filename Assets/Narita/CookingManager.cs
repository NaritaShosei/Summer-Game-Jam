using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    private List<(RecipeData recipe, string name)> _recipes = new();
    public List<(RecipeData recipe, string name)> Recipes => _recipes;

    public void AddRecipe((RecipeData recipe, string name) recipe)
    {
        _recipes.Add(recipe);
    }

    public void RecipeCheck(List<string> foods)
    {
        foreach (var recipes in _recipes)
        {
            if (ListsEqual(recipes.recipe.Foods.ToList(), foods))
            {
                Debug.Log(recipes.name);
                return;
            }
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
