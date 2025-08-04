using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CookingData
{
    [SerializeField] private string _foodName = "";
    [SerializeField] private RecipeData _recipeData;
    [SerializeField] private RecipeCommand _recipeCommand;

    public string FoodName => _foodName;
    public RecipeData RecipeData => _recipeData;
    public RecipeCommand RecipeCommand => _recipeCommand;
}
