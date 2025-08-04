using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    /// <summary>
    /// シーン移行する関数
    /// ボタンから呼び出す想定
    /// </summary>
    /// <param name="name"> シーンの名前</param>
    public static void ChangeScene(string name)
    {
        if (name != "")
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogWarning("シーンの名前を入力してください");
        }
    }
}
