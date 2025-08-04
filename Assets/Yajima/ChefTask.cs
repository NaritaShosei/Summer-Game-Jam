using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �����l�̃^�X�N���Ǘ�����X�N���v�g
/// </summary>
public class ChefTask : MonoBehaviour
{
    [SerializeField] CookingManager _cookingManager;
    [SerializeField] int _maxTask = 10;
    [SerializeField] float _countDown = 10;
    [SerializeField] Text _countDownText;

    Coroutine _countDownCoroutine;

    /// <summary>�J�E���g�_�E�����邽�߂̎��Ԃ��Ǘ�����ϐ�</summary>
    float _delta = 0;
    /// <summary>�^�X�N���I�[�o�[�t���[���Ă��邩�ǂ���</summary>
    bool _isTaskOver = false;
    /// <summary>�J�E���g�_�E�����Ă��邩�ǂ���</summary>
    bool _isCountDownNow = false;
    /// <summary>�Q�[���I�[�o�[���ǂ���</summary>
    bool _isGameOver = false;
    public bool IsGameOver { get { return _isGameOver; } }

    // Update is called once per frame
    void Update()
    {
        //�^�X�N�̃I�[�o�[�t���[�����m
        if (_cookingManager.Recipes.Count >= _maxTask)
        {
            _isTaskOver = true;
        }
        else
        {
            _isTaskOver = false;
        }

        //�^�X�N���I�[�o�[�t���[������J�E���g�_�E���J�n
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
            if( _countDownCoroutine != null)
            {
                StopCoroutine(_countDownCoroutine);
                _countDownCoroutine = null;
                _countDownText.text = "";
            }
            _isCountDownNow = false;
        }
    }
    
    /// <summary>
    /// �^�X�N���N���A�������ɂ��鏈��
    /// </summary>
    public void TaskClear()
    {
        _cookingManager.Recipes.RemoveAt(0);
    }

    /// <summary>
    /// �J�E���g�_�E������֐�
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
                _countDownText.text = "";
                _isGameOver = true;
                yield break;
            }
            else
            {
                _countDownText.text = _delta.ToString("00.00");
                yield return null;
            }
        }
    }
}
