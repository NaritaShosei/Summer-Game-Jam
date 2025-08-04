using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour, IFood
{
    public string GetName()
    {
        throw new System.NotImplementedException();
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