using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FoodElement : MonoBehaviour, IFood
{
    [SerializeField] string _foodName;
    [SerializeField] GameObject _foodPrefab;

    public string GetName()
    {

        return _foodName;
    }

    public GameObject GetObject()
    {
        return Instantiate(_foodPrefab, transform.position, Quaternion.identity);
    }
}
