using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ImageData/DataBase", fileName = "ImageDataBase")]
public class ImageDataBase : ScriptableObject
{
    [SerializeField] private ImageData[] _imageData;
    [SerializeField, Header("煮るの画像")] private Sprite _simmerImage;
    [SerializeField, Header("焼くの画像")] private Sprite _bakeImage;
    [SerializeField, Header("揚げ物の画像")] private Sprite _fryImage;

    public Sprite GetSprite(string name)
    {
        foreach (var item in _imageData)
        {
            if (item.Image.name == name)
            {
                return item.Image.sprite;
            }
        }
        return null;
    }

    public Sprite GetSprite(CookingMethod type)
    {
        return type switch
        {
            CookingMethod.Simmer => _simmerImage,
            CookingMethod.Bake => _bakeImage,
            CookingMethod.Fry => _fryImage,
            _ => null // 予期しない値には null を返す（例外防止）
        };
    }

}