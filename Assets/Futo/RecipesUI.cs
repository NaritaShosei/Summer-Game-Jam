using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RecipesUI : MonoBehaviour
{
    [SerializeField] List<string> _task = new List<string>();
    [SerializeField] List<GameObject> _flame = new List<GameObject>();
    [SerializeField] List<Image> _foodImage = new List<Image>();
    [SerializeField] List<Image> _foodCokingMethod = new List<Image>();
    private OrderManager _orderManager;
    private ImageDatabase _imageDatabase;
    private void Start()
    {
        _orderManager = FindAnyObjectByType<OrderManager>();
        _imageDatabase = GetComponent<ImageDatabase>();
        for (int i  = 0; i < _flame.Count; i++)
        {
            _flame[i].SetActive(false);
        }
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            AddTask("カレー");
        }
        if(Input.GetKeyDown(KeyCode.I))
        {
            RemoveTask();
        }
    }
    void MakeUI()
    {
        for (int i = 0; i < _task.Count; i++)
        {
            _flame[i].SetActive(true);

            var (recipe, name) = _orderManager.Food;

            if (recipe == null)
            {
                Debug.LogWarning($"レシピが見つかりません: {_task[i]}");
                continue;
            }

            _foodImage[i].sprite = _imageDatabase.GetImage(name);

            string[] _recipes = recipe.Foods;

            for (int j = 0; j < _recipes.Length; j++)
            {
                Image images = _flame[i].GetComponentInChildren<Image>();
                images.sprite = _imageDatabase.GetImage(_recipes[j]);
            }
        }
    }

    public void AddTask(string task)
    {
        _task.Add(task);
        MakeUI();
    }

    public void RemoveTask()
    {
        _task.RemoveAt(0);
        MakeUI();
    }
}
