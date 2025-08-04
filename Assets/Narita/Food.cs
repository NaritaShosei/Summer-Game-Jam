using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    [SerializeField] private string _foodName;
    public string GetName()
    {
        return _foodName;
    }
}

public interface IFood
{
    string GetName();
}

public interface ITarget
{
    void SetName(string name);
}