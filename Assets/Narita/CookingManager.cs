using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingManager : MonoBehaviour
{
    private List<(RecipeData recipe, string name)> _recipes;
    public List<(RecipeData recipe, string name)> Recipes => _recipes;

    public void AddRecipe((RecipeData recipe, string name) recipe)
    {
        _recipes.Add(recipe);
    }

}
