using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropper : MonoBehaviour
{
    [SerializeField] private float _distance = 9f;

    private Camera _mainCamera;
    private bool _isClicked;
    private string _name;
    private GameObject _dragObjectPrefab;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_isClicked)
        {
            _dragObjectPrefab.transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance));
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (UpdateRaycast(out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out FoodElement food))
                {
                    _name = food.GetName();
                    _dragObjectPrefab = food.FoodPrefab();

                    _dragObjectPrefab = Instantiate(_dragObjectPrefab, hit.point, Quaternion.identity);

                    _isClicked = true;
                    Debug.Log(_name);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!_isClicked) { return; }
            Destroy(_dragObjectPrefab);

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
