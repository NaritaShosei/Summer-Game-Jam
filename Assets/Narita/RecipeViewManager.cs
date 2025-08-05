using System.Collections.Generic;
using UnityEngine;

public class RecipeViewManager : MonoBehaviour
{
    [SerializeField] private RecipeView[] _recipeViews;
    private ImageManager _imageManager;

    // 表示中のデータ
    private readonly Queue<(RecipeData recipe, string name)> _queue = new();

    private void Start()
    {
        _imageManager = FindAnyObjectByType<ImageManager>();

        foreach (var view in _recipeViews)
        {
            view.gameObject.SetActive(false);
        }
    }

    public void AddView((RecipeData recipe, string name) data)
    {
        // 上限に達していたら追加しない
        if (_queue.Count >= _recipeViews.Length)
            return;

        _queue.Enqueue(data);
        UpdateViews();
    }

    public void RemoveView()
    {
        if (_queue.Count == 0)
            return;

        _queue.Dequeue();
        UpdateViews();
    }

    private void UpdateViews()
    {
        // 全て非表示
        foreach (var view in _recipeViews)
        {
            view.gameObject.SetActive(false);
        }

        // キューの順番で再セット
        var array = _queue.ToArray();
        for (int i = 0; i < array.Length; i++)
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
