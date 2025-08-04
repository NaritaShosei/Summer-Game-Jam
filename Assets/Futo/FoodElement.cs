using UnityEngine;

public class FoodElement : MonoBehaviour, IFood
{
    [SerializeField] string _foodName;
    [SerializeField] GameObject _foodPrefab;

    public string GetName()
    {
        return _foodName;
    }

    public GameObject FoodPrefab()
    {
        return _foodPrefab;
    }
}
