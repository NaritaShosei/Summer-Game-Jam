using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    [SerializeField, Tooltip("コマンドを表示するテキスト")] Text _commandText;

    /// <summary>現在入力中のコマンドのリスト</summary>
    List<KeyCode> _nowCommandList;
    /// <summary>現在入力中のコマンド</summary>
    KeyCode _typeKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        _nowCommandList = new List<KeyCode>();
    }

    // Update is called once per frame
    void Update()
    {
        //入力受け取りの初期化
        _typeKeyCode = KeyCode.None;

        //入力受け取り
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _typeKeyCode = KeyCode.DownArrow;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _typeKeyCode = KeyCode.UpArrow;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _typeKeyCode = KeyCode.LeftArrow;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _typeKeyCode = KeyCode.RightArrow;
        }

        //矢印のどれかが押されたら
        if (_typeKeyCode != KeyCode.None)
        {
            Debug.Log(_typeKeyCode.ToString());
            //入力したキーをリストに追加
            _nowCommandList.Add(_typeKeyCode);
            _commandText.text = GetNowCommandText();
        }

        //エンターキー入力
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Order");
            GetNowCommand();
            //コマンドを初期化
            ResetCommand();
        }
    }

    /// <summary>
    /// 現在までに入力したコマンドを返す関数
    /// </summary>
    /// <returns> 現在入力中のコマンド</returns>
    public List<KeyCode> GetNowCommand()
    {
        foreach (KeyCode keyCode in _nowCommandList)
        {
            Debug.Log(keyCode.ToString());
        }
        return _nowCommandList;
    }

    /// <summary>
    /// コマンドを初期化する関数
    /// </summary>
    void ResetCommand()
    {
        _nowCommandList.Clear();
        _commandText.text = GetNowCommandText();
    }

    /// <summary>
    /// 現在入力したコマンドを文字列で返す関数
    /// </summary>
    /// <returns> 現在入力中のコマンドの文字列</returns>
    string GetNowCommandText()
    {
        string returnText = "";
        //表示するコマンドを作成
        for (int i = 0; i < _nowCommandList.Count; i++)
        {
            switch (_nowCommandList[i])
            {
                case KeyCode.LeftArrow:
                    returnText += "<color=red>←</color>";
                    break;
                case KeyCode.RightArrow:
                    returnText += "<color=blue>→</color>";
                    break;
                case KeyCode.UpArrow:
                    returnText += "<color=green>↑</color>";
                    break;
                case KeyCode.DownArrow:
                    returnText += "<color=yellow>↓</color>";
                    break;
                default:
                    break;
            }
            returnText += " ";
        }

        return returnText;
    }
}
