using System;
using UnityEngine;
using UnityEngine.UI;

public class NowCommandText : MonoBehaviour
{
    [SerializeField]
    private Typing _typing;

    private Func<string> _getNowCommandTextFunc;

    private Text _nowCommandText;

    private void Start()
    {
        _nowCommandText = GetComponent<Text>();
        _getNowCommandTextFunc = _typing.GetNowCommandFunc();
    }
}
