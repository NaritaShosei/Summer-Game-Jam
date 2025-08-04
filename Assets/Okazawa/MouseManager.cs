using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private string _draggedFoodElement = string.Empty;

    private 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���N���b�N
        {
            ThrowRay();
        }
    }

    /// <summary>
    /// �}�E�X���烌�C�L���X�g���āA�N���b�N���ꂽ�I�u�W�F�N�g���擾���܂��B
    /// </summary>
    private void ThrowRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // ���C�L���X�g���q�b�g�����I�u�W�F�N�g���擾
            GameObject clickedObject = hit.collider.gameObject;

            if (clickedObject.TryGetComponent(out FoodElement foodElement))
            {
                Debug.Log("�H�ނ�������܂���: " + foodElement.name);

                //_draggedFoodElement = foodElement.FoodName; // ������FoodElement�̃v���p�e�B�ɃA�N�Z�X
            }
            else
            {
                Debug.LogWarning($"�N���b�N���ꂽ{foodElement.name}��FoodElement�ł͂���܂���B");
            }
        }
    }
}