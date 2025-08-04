using UnityEngine;

public class FoodElement : MonoBehaviour, IFood
{
    [SerializeField] string _foodName;

    public string GetName()
    {
        return _foodName;
    }
}
