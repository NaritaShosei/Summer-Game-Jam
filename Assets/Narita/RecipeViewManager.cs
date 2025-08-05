using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecipeViewManager : MonoBehaviour
{
    private ImageManager _imageManager;
    [SerializeField] private RecipeView[] _recipeViews;

    private void Start()
    {
        _imageManager = FindAnyObjectByType<ImageManager>();
    }
    public void AddView((RecipeData recipe, string name) data)
    {
        var dataBase = _imageManager.DataBase;
        var food = dataBase.GetSprite(data.name);
        var element = new Sprite[data.recipe.Foods.Length];
        for (int i = 0; i < data.recipe.Foods.Length; i++)
        {
            element[i] = dataBase.GetSprite(data.recipe.Foods[i]);
        }

        var method = dataBase.GetSprite(data.recipe.CookingMethod);
    }
}
