using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    /// <summary>
    /// �V�[���ڍs����֐�
    /// �{�^������Ăяo���z��
    /// </summary>
    /// <param name="name"> �V�[���̖��O</param>
    public void ChangeScene(string name)
    {
        if (name != "")
        {
            SceneManager.LoadScene(name);
        }
        else
        {
            Debug.LogWarning("�V�[���̖��O����͂��Ă�������");
        }
    }
}
