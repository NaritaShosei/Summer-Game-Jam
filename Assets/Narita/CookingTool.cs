using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookingTool : MonoBehaviour
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
    }

    public void Cooking()
    {
        _cookingManager.RecipeCheck(_foods);
    }
}
