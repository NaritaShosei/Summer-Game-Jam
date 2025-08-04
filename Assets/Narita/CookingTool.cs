using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTool : MonoBehaviour, ITarget
{
    [SerializeField] private CookingMethod _cookingMethod;
    private List<string> _foods = new();
    private OrderManager _orderManager;
    private CookingManager _cookingManager;
    private void Start()
    {
        _orderManager = FindAnyObjectByType<OrderManager>();
        _cookingManager = FindAnyObjectByType<CookingManager>();
    }

    public void AddFood(string food)
    {
        _foods.Add(food);
        Debug.Log(string.Join(" ", _foods));
    }

    public void Cooking()
    {
        _cookingManager.RecipeCheck(_foods);
        _foods.Clear();
    }

    public void SetName(string name)
    {
        _foods.Add(name);
        Debug.Log(string.Join(" ", _foods));
    }
}
