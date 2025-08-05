using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingWindow : MonoBehaviour, ITarget
{
    private CookingManager _cookingManager;
    private RecipeViewManager _recipeViewManager;

    private void Start()
    {
        _recipeViewManager = FindAnyObjectByType<RecipeViewManager>();
        _cookingManager = FindAnyObjectByType<CookingManager>();
    }

    public void SetName(string name)
    {
        _cookingManager.CheckFood(name);
    }
}
