using System.Collections.Generic;
using UnityEngine;

public class RecipeViewManager : MonoBehaviour
{
    [SerializeField] private RecipeView[] _recipeViews;
    private ImageManager _imageManager;

    private void Start()
    {
        _imageManager = FindAnyObjectByType<ImageManager>();

        foreach (var view in _recipeViews)
        {
            view.gameObject.SetActive(false);
        }
    }

    public void UpdateViews(Queue<(RecipeData recipe, string name)> recipes)
    {
        // 全て非表示
        foreach (var view in _recipeViews)
        {
            view.gameObject.SetActive(false);
        }

        // 渡されたキューから順にセット
        var array = recipes.ToArray();
        for (int i = 0; i < array.Length && i < _recipeViews.Length; i++)
        {
            var data = array[i];
            var dataBase = _imageManager.DataBase;
            var food = dataBase.GetSprite(data.name);

            var elements = new Sprite[data.recipe.Foods.Length];
            for (int j = 0; j < data.recipe.Foods.Length; j++)
            {
                elements[j] = dataBase.GetSprite(data.recipe.Foods[j]);
            }

            var method = dataBase.GetSprite(data.recipe.CookingMethod);
            _recipeViews[i].SetRecipe(food, elements, method);
            _recipeViews[i].gameObject.SetActive(true);
        }
    }
}
