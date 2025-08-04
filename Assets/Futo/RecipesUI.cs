using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;

public class RecipesUI : MonoBehaviour
{
    [SerializeField] List<string> _task = new List<string>();
    [SerializeField] GameObject _taskFlame;
    [SerializeField] GameObject _flame;
    void MakeUI()
    {
        Instantiate(_flame);
    }
    public void AddTask(string task)
    {
        _task.Add(task);
    }
    public void RemoveTask()
    {
        _task.RemoveAt(0);
    }
}
