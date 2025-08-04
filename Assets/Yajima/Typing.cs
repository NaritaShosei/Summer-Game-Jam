using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Typing : MonoBehaviour
{
    [SerializeField, Tooltip("�R�}���h��\������e�L�X�g")] Text _commandText;

    /// <summary>���ݓ��͒��̃R�}���h�̃��X�g</summary>
    List<KeyCode> _nowCommandList;
    /// <summary>���ݓ��͒��̃R�}���h</summary>
    KeyCode _typeKeyCode;
    // Start is called before the first frame update
    void Start()
    {
        _nowCommandList = new List<KeyCode>();
    }

    // Update is called once per frame
    void Update()
    {
        //���͎󂯎��̏�����
        _typeKeyCode = KeyCode.None;

        //���͎󂯎��
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

        //���̂ǂꂩ�������ꂽ��
        if (_typeKeyCode != KeyCode.None)
        {
            Debug.Log(_typeKeyCode.ToString());
            //���͂����L�[�����X�g�ɒǉ�
            _nowCommandList.Add(_typeKeyCode);
            _commandText.text = GetNowCommandText();
        }

        //�G���^�[�L�[����
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Order");
            GetNowCommand();
            //�R�}���h��������
            ResetCommand();
        }
    }

    /// <summary>
    /// ���݂܂łɓ��͂����R�}���h��Ԃ��֐�
    /// </summary>
    /// <returns> ���ݓ��͒��̃R�}���h</returns>
    public List<KeyCode> GetNowCommand()
    {
        foreach (KeyCode keyCode in _nowCommandList)
        {
            Debug.Log(keyCode.ToString());
        }
        return _nowCommandList;
    }

    /// <summary>
    /// �R�}���h������������֐�
    /// </summary>
    void ResetCommand()
    {
        _nowCommandList.Clear();
        _commandText.text = GetNowCommandText();
    }

    /// <summary>
    /// ���ݓ��͂����R�}���h�𕶎���ŕԂ��֐�
    /// </summary>
    /// <returns> ���ݓ��͒��̃R�}���h�̕�����</returns>
    string GetNowCommandText()
    {
        string returnText = "";
        //�\������R�}���h���쐬
        for (int i = 0; i < _nowCommandList.Count; i++)
        {
            switch (_nowCommandList[i])
            {
                case KeyCode.LeftArrow:
                    returnText += "<color=red>��</color>";
                    break;
                case KeyCode.RightArrow:
                    returnText += "<color=blue>��</color>";
                    break;
                case KeyCode.UpArrow:
                    returnText += "<color=green>��</color>";
                    break;
                case KeyCode.DownArrow:
                    returnText += "<color=yellow>��</color>";
                    break;
                default:
                    break;
            }
            returnText += " ";
        }

        return returnText;
    }
}
