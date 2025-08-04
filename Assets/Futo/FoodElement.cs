using UnityEngine;

public class FoodElement: MonoBehaviour
{
    [SerializeField] string _foodName;
    public string FoodName => _foodName;
}
