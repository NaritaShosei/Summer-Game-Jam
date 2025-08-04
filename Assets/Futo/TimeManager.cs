using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float _timeLimit = 60f;
    [SerializeField] Text _timeText;
    float _timer;
    public float Timer => _timer;
    private void Start()
    {
        _timer = _timeLimit;
    }
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            Debug.Log("TimeUp");
            _timer = 0f;
        }
        _timeText.text = _timer.ToString("00.00");
    }
}