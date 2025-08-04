using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RecipeCommand
{
    [SerializeField] List<KeyCode> _keyList = new List<KeyCode>();

    /// <summary>
    /// コマンド情報を取得するプロパティ
    /// </summary>
    public List<KeyCode> KeyList { get { return _keyList; } }
}
