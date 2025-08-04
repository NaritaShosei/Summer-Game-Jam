using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class RecipeData
{
    [SerializeField] private string[] _foods;
    [SerializeField] private CookingType _cookingType;
    public string[] Foods => _foods;
    public CookingType CookingType => _cookingType;
}
public enum CookingType
{
    // 生
    None = 0,
    // 煮る
    Simmer = 1,
    // 焼く
    Bake = 2,
    // 揚げる
    Fire = 3,
}