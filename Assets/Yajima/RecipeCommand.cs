using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RecipeCommand
{
    [SerializeField] List<KeyCode> _keyList = new List<KeyCode>();

    /// <summary>
    /// �R�}���h�����擾����v���p�e�B
    /// </summary>
    public List<KeyCode> KeyList { get { return _keyList; } }
}
