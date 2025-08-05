using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ImageData/Data", fileName = "ImageData")]
public class ImageData : ScriptableObject
{
    [SerializeField] private string _name = "";
    [SerializeField] private Sprite _sprite;
    public (string name, Sprite sprite) Image => (_name, _sprite);
}
