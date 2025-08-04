using UnityEngine;

public class FoodChecker : MonoBehaviour
{
    [SerializeField] GameObject FoodGameObject;
    [SerializeField] Food Food;
    [SerializeField] string FoodName;
    void Start()
    {
        Food = FoodGameObject.GetComponent<Food>();
        FoodName = Food.FoodName;
    }
}
