using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RecipeCommand
{
    [SerializeField] List<Arrow> _keyList = new List<Arrow>();

    /// <summary>
    /// コマンド情報を取得するプロパティ
    /// </summary>
    public List<Arrow> KeyList { get { return _keyList; } }
}
