using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeData
{
    [SerializeField] private string[] _foods;
    [SerializeField] private CookingMethod _cookingType;
    public string[] Foods => _foods;
    public CookingMethod CookingType => _cookingType;
}
public enum CookingMethod
{
    [InspectorName("煮る")]
    Simmer = 0,
    [InspectorName("焼く")]
    Bake = 1,
    [InspectorName("揚げる")]
    Fry = 2,
}