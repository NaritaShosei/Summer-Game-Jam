using UnityEngine;

/// <summary>
/// �ړ����������I�u�W�F�N�g�ɃA�^�b�`���Ă�������
/// </summary>
public class MouseDragManager : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        // �I�u�W�F�N�g�ƃ}�E�X�̈ʒu�������L�^����
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        // �}�E�X�̈ʒu�ɃI�u�W�F�N�g���ړ�������
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // �}�E�X�̃X�N���[�����W�����[���h���W�ɕϊ�
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
