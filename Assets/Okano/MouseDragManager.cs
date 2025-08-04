using UnityEngine;

/// <summary>
/// 移動させたいオブジェクトにアタッチしてください
/// </summary>
public class MouseDragManager : MonoBehaviour
{
    private Vector3 offset;
    private float zCoord;

    void OnMouseDown()
    {
        // オブジェクトとマウスの位置差分を記録する
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        offset = gameObject.transform.position - GetMouseWorldPos();
    }

    void OnMouseDrag()
    {
        // マウスの位置にオブジェクトを移動させる
        transform.position = GetMouseWorldPos() + offset;
    }

    private Vector3 GetMouseWorldPos()
    {
        // マウスのスクリーン座標をワールド座標に変換
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
