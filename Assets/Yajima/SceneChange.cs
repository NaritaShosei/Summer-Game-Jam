using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    [SerializeField] Image _fadeImage;
    [SerializeField] int _fadeCount = 8;
    [SerializeField] float _fadeOutTime = 1;

    float _delta = 0;
    float _fadeTime = 0;

    private void Start()
    {
        _fadeImage.enabled = false;
        _fadeImage.fillAmount = 0;
    }

    /// <summary>
    /// �V�[���ڍs����֐�
    /// �{�^������Ăяo���z��
    /// </summary>
    /// <param name="name"> �V�[���̖��O</param>
    public void ChangeScene(string name)
    {
        if (name != "")
        {
            if (name == "Test2")
            {
                _fadeImage.enabled = true;
                StartCoroutine(FadeOut(name));
            }
            else
            {
                SceneManager.LoadScene(name);
            }
        }
        else
        {
            Debug.LogWarning("�V�[���̖��O����͂��Ă�������");
        }
    }

    /// <summary>
    /// �t�F�[�h�A�E�g����֐�
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    IEnumerator FadeOut(string name)
    {
        while (true)
        {
            if (_delta > _fadeOutTime + 0.1f)
            {
                SceneManager.LoadScene(name);
                yield break;
            }
            else
            {
                _delta += Time.deltaTime;
                if (_delta >= _fadeTime)
                {
                    _fadeTime += _fadeOutTime / _fadeCount;
                    _fadeImage.fillAmount += _fadeOutTime / _fadeCount;
                    Debug.Log(_fadeTime);
                    Debug.Log(_fadeOutTime / _fadeCount);
                }
                yield return null;
            }
        }
    }
}
