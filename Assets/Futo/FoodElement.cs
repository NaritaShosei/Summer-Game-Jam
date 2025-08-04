using UnityEngine;

public class FoodElement: MonoBehaviour,IFood
{
    [SerializeField] string _foodName;
    public string FoodName => _foodName;

    public string GetName()
    {
        throw new System.NotImplementedException();
    }
}
