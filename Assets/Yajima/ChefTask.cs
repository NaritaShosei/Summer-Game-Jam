using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 料理人のタスクを管理するスクリプト
/// </summary>
public class ChefTask : MonoBehaviour
{
    [SerializeField] CookingManager _cookingManager;
    [SerializeField] int _maxTask = 10;
    [SerializeField] float _countDown = 10;
    [SerializeField] Text _countDownText;

    Coroutine _countDownCoroutine;

    /// <summary>カウントダウンするための時間を管理する変数</summary>
    float _delta = 0;
    /// <summary>タスクがオーバーフローしているかどうか</summary>
    bool _isTaskOver = false;
    /// <summary>カウントダウンしているかどうか</summary>
    bool _isCountDownNow = false;
    /// <summary>ゲームオーバーかどうか</summary>
    bool _isGameOver = false;
    public bool IsGameOver { get { return _isGameOver; } }

    // Update is called once per frame
    void Update()
    {
        //タスクのオーバーフローを検知
        if (_cookingManager.Recipes.Count >= _maxTask)
        {
            _isTaskOver = true;
        }
        else
        {
            _isTaskOver = false;
        }

        //タスクがオーバーフローしたらカウントダウン開始
        if (_isTaskOver)
        {
            if (!_isCountDownNow)
            {
                _isCountDownNow = true;
                _countDownCoroutine = StartCoroutine(CountDown());
            }
        }
        else
        {
            if (_countDownCoroutine != null)
            {
                StopCoroutine(_countDownCoroutine);
                _countDownCoroutine = null;
                // _countDownText.text = "";
            }
            _isCountDownNow = false;
        }
    }

    /// <summary>
    ///// タスクをクリアした時にする処理
    ///// </summary>
    //public void TaskClear()
    //{
    //    _cookingManager.Recipes.RemoveAt(0);
    //}

    /// <summary>
    /// カウントダウンする関数
    /// </summary>
    /// <returns></returns>
    IEnumerator CountDown()
    {
        _delta = _countDown;
        while (true)
        {
            _delta -= Time.deltaTime;
            if (_delta <= 0)
            {
                Debug.Log("TaskOverFlow");
                //_countDownText.text = "";
                _isGameOver = true;
                yield break;
            }
            else
            {
                // _countDownText.text = _delta.ToString("00.00");
                yield return null;
            }
        }
    }
}
