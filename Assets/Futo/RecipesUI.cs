using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RecipesUI : MonoBehaviour
{
    [SerializeField] List<GameObject> _task = new List<GameObject>();
    [SerializeField] GameObject _flame;
    void MakeUI()
    {
    }

    public void AddTask(GameObject task)
    {
        _task.Add(task);
    }
    public void RemoveTask()
    {
        _task.RemoveAt(0);
    }
}
