using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    [SerializeField] private string _foodName;

    [SerializeField] private GameObject _foodPrefab;
    public string GetName()
    {
        return _foodName;
    }

    public GameObject FoodPrefab()
    {
        return _foodPrefab;
    }
}

public interface IFood
{
    string GetName();
    GameObject FoodPrefab();
}

public interface ITarget
{
    void SetName(string name);
}