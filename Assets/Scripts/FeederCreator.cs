using System;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using Unity.VisualScripting;

public class FeederCreator : MonoBehaviour
{
    // private float startX = RectTransform.position.x;
    [SerializeField] private Button ButtonFeeder1;
    [SerializeField] private Button ButtonFeeder2;
    [SerializeField] private Button ButtonFeeder3;
    [SerializeField] private Button CreateFeeder;
    [SerializeField] private Button CloseMenu;
    [SerializeField] private Button TestOpenButton;
    [SerializeField] private GameObject Panel; 
    [SerializeField] private GameObject[] _Feeders;

    private int Counter = 0;
    private bool isOpen = false;
    public bool isTargeted = false;

    // private RectTransform rectTransform;
    private void Awake()
    {
        ButtonFeeder1.onClick.AddListener(() => feederCounter(1));
        ButtonFeeder2.onClick.AddListener(() => feederCounter(2));
        ButtonFeeder3.onClick.AddListener(() => feederCounter(3));
        CreateFeeder.onClick.AddListener(Create);
        CloseMenu.onClick.AddListener(Close);
        // TestOpenButton.onClick.AddListener(Open);
    }
    private void Create() 
    {
        if (isTargeted)
        {
            Debug.Log($"Создана кормушка {Counter}");
            Instantiate(_Feeders[Counter - 1], transform.parent);
            Close();
            Destroy(gameObject);
        }
    }
    private void feederCounter(int number)
    {
        Counter = number;
    }
    private void Open()
    {
        isOpen = true;
        Panel.transform.DOMoveX(1550, 1);
    }
    private void Close()
    {
        isOpen = false;
        isTargeted = false;
        Panel.transform.DOMoveX(2500, 1);
    }
}
