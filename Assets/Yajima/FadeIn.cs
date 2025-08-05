using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    [SerializeField] int _fadeCount = 8;
    [SerializeField] float _fadeOutTime = 1;

    Image _image;

    float _delta = 0;
    float _fadeTime = 0;

    bool _isFadeEnd = false;
    public bool IsFadeEnd { get { return _isFadeEnd; }}

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
        StartCoroutine(FadeInCoroutine());
    }

    /// <summary>
    /// フェードアウトする関数
    /// </summary>
    /// <returns></returns>
    IEnumerator FadeInCoroutine()
    {
        while (true)
        {
            if (_delta > _fadeOutTime)
            {
                gameObject.SetActive(false);
                _isFadeEnd = true;
                yield break;
            }
            else
            {
                _delta += Time.deltaTime;
                if (_delta >= _fadeTime)
                {
                    _fadeTime += _fadeOutTime / _fadeCount;
                    _image.fillAmount -= _fadeOutTime / _fadeCount;
                    Debug.Log(_fadeTime);
                    Debug.Log(_fadeOutTime / _fadeCount);
                }
                yield return null;
            }
        }
    }
}
