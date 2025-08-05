using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingWindow : MonoBehaviour, ITarget
{
    private CookingManager _cookingManager;

    private void Start()
    {
        _cookingManager = FindAnyObjectByType<CookingManager>();
    }

    public void SetName(string name)
    {
        _cookingManager.CheckFood(name);
    }
}
