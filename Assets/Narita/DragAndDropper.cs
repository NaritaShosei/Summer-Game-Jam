using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDropper : MonoBehaviour
{
    [SerializeField] private float _distance = 9f;

    private Camera _mainCamera;
    private bool _isClicked;
    private string _name;
    private GameObject _dragObject;

    private void Start()
    {
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if (_isClicked && _dragObject)
        {
            _dragObject.transform.position = _mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, _distance));
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (UpdateRaycast(out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out IFood food))
                {
                    _name = food.GetName();
                    _dragObject = food.GetObject();
                    _dragObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                    _isClicked = true;
                    Debug.Log(_name);
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (!_isClicked) { return; }
            Destroy(_dragObject);
            _dragObject = null;
            if (UpdateRaycast(out RaycastHit hit))
            {
                if (hit.collider.TryGetComponent(out ITarget target))
                {
                    target.SetName(_name);
                }
            }
            _isClicked = false;
            _name = null;
        }
    }

    private bool UpdateRaycast(out RaycastHit hit)
    {
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log($"Hit:{hit.collider.name} {hit.point} at distance {hit.distance}");
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            return true;
        }
        else
        {
            Debug.DrawRay(ray.origin, ray.direction * _distance, Color.green);
            return false;
        }
    }
}
