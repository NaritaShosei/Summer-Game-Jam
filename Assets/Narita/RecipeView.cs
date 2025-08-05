using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecipeView : MonoBehaviour
{
    private ImageManager _imageManager;
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image[] _images;
    [SerializeField] private Image _methodImage;

    private void Start()
    {
        _imageManager = FindAnyObjectByType<ImageManager>();
    }

    public void SetRecipe(Sprite food, Sprite[] foodElement, Sprite method)
    {
        gameObject.SetActive(true);

        _foodImage.sprite = food;

        for (int i = 0; i < _images.Length; i++)
        {
            if (foodElement.Length <= i)
            {
                _images[i].gameObject.SetActive(false);
            }
            else
            {
                _images[i].sprite = foodElement[i];
                _images[i].gameObject.SetActive(true);
            }
        }
        _methodImage.sprite = method;
    }
}
