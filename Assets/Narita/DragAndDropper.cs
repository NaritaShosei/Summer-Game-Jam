using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropper : MonoBehaviour
{
    [SerializeField] private float _distance = 9f;

    private Camera _mainCamera;
    private bool _isClicked;
    private string _name;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (UpdateRaycast(out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out Food food))
                {
                    _name = food.FoodName;
                    _isClicked = true;
                    Debug.Log(_name);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!_isClicked) { return; }
            if (UpdateRaycast(out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out CookingTool tool))
                {
                    tool.AddFood(_name);
                }
            }
            _isClicked = false;
            _name = null;
        }
    }

    private bool UpdateRaycast(out RaycastHit hit)
    {
        Vector3 screenPos = Input.mousePosition;
        screenPos.z = _distance;

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        Ray ray = new Ray(worldPos, _mainCamera.transform.forward);

        if (Physics.Raycast(ray, out hit, _distance))
        {
            Debug.Log($"Hit: {hit.collider.name} at distance {hit.distance}");
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            return true;
        }
        else
        {
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * _distance, Color.green);
            return false;
        }
    }
}
