using UnityEngine;

public class FoodChecker : MonoBehaviour
{
    [SerializeField] TimeManager timeManager;
    [SerializeField] float _time;
    private void Update()
    {
        _time = timeManager.Timer;
    }
}
