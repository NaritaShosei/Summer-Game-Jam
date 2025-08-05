using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private ImageDataBase _dataBase;
    public ImageDataBase DataBase => _dataBase;
}
