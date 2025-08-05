using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class FoodAndCommandData
{
    [Header("FoodImage And CommandText Pair")]
    public Image _foodImage;
    public Text _commandText;
}

public class OrderUI : MonoBehaviour
{
    [SerializeField] List<FoodAndCommandData> _foodAndCommand;

    OrderManager _orderManager;
    ImageManager _imageManager;

    // Start is called before the first frame update
    void Start()
    {
        _orderManager = FindAnyObjectByType<OrderManager>();
        _imageManager = FindAnyObjectByType<ImageManager>();
    }

    // Update is called once per frame
    void Update()
    {
        ImageUpdate();
    }

    void ImageUpdate()
    {
        var keyList = _orderManager.Keys;
        for (int i = 0; i < keyList.Count; i++)
        {
            _foodAndCommand[i]._foodImage.sprite = _imageManager.DataBase.GetSprite(_orderManager.GetFoodName(keyList[i]));
            TextUpdate(keyList[i], _foodAndCommand[i]._commandText);
        }
    }

    void TextUpdate(List<Arrow> keys, Text text)
    {
        text.text = "";
        foreach (var key in keys)
        {
            switch (key)
            {
                case Arrow.LeftArrow:
                    text.text += "<color=red>Å©</color>";
                    break;
                case Arrow.RightArrow:
                    text.text += "<color=blue>Å®</color>";
                    break;
                case Arrow.UpArrow:
                    text.text += "<color=green>Å™</color>";
                    break;
                case Arrow.DownArrow:
                    text.text += "<color=yellow>Å´</color>";
                    break;
                default:
                    break;
            }
            text.text += " ";
        }
    }
}
