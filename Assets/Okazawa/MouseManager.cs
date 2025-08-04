using UnityEngine;

public class MouseManager : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    private string _draggedFoodElement = string.Empty;

    private 

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 左クリック
        {
            ThrowRay();
        }
    }

    /// <summary>
    /// マウスからレイキャストして、クリックされたオブジェクトを取得します。
    /// </summary>
    private void ThrowRay()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // レイキャストがヒットしたオブジェクトを取得
            GameObject clickedObject = hit.collider.gameObject;

            if (clickedObject.TryGetComponent(out FoodElement foodElement))
            {
                Debug.Log("食材が見つかりました: " + foodElement.name);

                //_draggedFoodElement = foodElement.FoodName; // ここでFoodElementのプロパティにアクセス
            }
            else
            {
                Debug.LogWarning($"クリックされた{foodElement.name}はFoodElementではありません。");
            }
        }
    }
}