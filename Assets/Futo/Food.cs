using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] string _foodName;

    public string FoodName => _foodName;
}
