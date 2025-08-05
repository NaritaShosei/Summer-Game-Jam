using UnityEngine;
using UnityEngine.UI;

public class RecipeView : MonoBehaviour
{
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image[] _images;
    [SerializeField] private Image _methodImage;
    private CanvasGroup _canvasGroup;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup == null)
        {
            _canvasGroup = gameObject.AddComponent<CanvasGroup>();
        }
    }

    public void SetRecipe(Sprite food, Sprite[] foodElement, Sprite method)
    {
        Show();

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

    public void Hide()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void Show()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}
