using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    [SerializeField, Tooltip("コマンドを表示するテキスト")] Text _commandText;

    /// <summary>現在入力中のコマンドのリスト</summary>
    List<Arrow> _nowCommandList;
    /// <summary>現在入力中のコマンド</summary>
    Arrow _typeKeyCode;
    private OrderManager _orderManager;

    // Start is called before the first frame update
    void Start()
    {
        _nowCommandList = new List<Arrow>();
        _orderManager = FindAnyObjectByType<OrderManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //入力受け取りの初期化
        _typeKeyCode = Arrow.None;

        //入力受け取り
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _typeKeyCode = Arrow.DownArrow;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _typeKeyCode = Arrow.UpArrow;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _typeKeyCode = Arrow.LeftArrow;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _typeKeyCode = Arrow.RightArrow;
        }

        //矢印のどれかが押されたら
        if (_typeKeyCode != Arrow.None)
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

            _orderManager.CommandEnter(_nowCommandList);
            //コマンドを初期化
            ResetCommand();
        }
    }

    /// <summary>
    /// 現在までに入力したコマンドを返す関数
    /// </summary>
    /// <returns> 現在入力中のコマンド</returns>
    public List<Arrow> GetNowCommand()
    {
        foreach (Arrow keyCode in _nowCommandList)
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
                case Arrow.LeftArrow:
                    returnText += "<color=red>←</color>";
                    break;
                case Arrow.RightArrow:
                    returnText += "<color=blue>→</color>";
                    break;
                case Arrow.UpArrow:
                    returnText += "<color=green>↑</color>";
                    break;
                case Arrow.DownArrow:
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
public enum Arrow
{
    None = 0,
    UpArrow = 1,
    DownArrow = 2,
    RightArrow = 3,
    LeftArrow = 4,
}