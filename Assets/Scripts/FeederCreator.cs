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

    [SerializeField] private GameObject feeder1;
    [SerializeField] private GameObject feeder2;
    [SerializeField] private GameObject feeder3;

    [SerializeField] private GameObject[] _Feeders;

    private int Counter = 0;
    private bool isOpen = false;

   // private RectTransform rectTransform;
    private void Awake()
    {
        ButtonFeeder1.onClick.AddListener(() => feederCounter(1));
        ButtonFeeder2.onClick.AddListener(() => feederCounter(2));
        ButtonFeeder3.onClick.AddListener(() => feederCounter(3));
        CreateFeeder.onClick.AddListener(Create);
        CloseMenu.onClick.AddListener(Close);
        TestOpenButton.onClick.AddListener(Open);
    }
    void Update()
    {
        //uiElement.anchoredPosition
    }

    private void Create() 
    {
        Debug.Log($"Создана кормушка {Counter}");
    }
    private void feederCounter(int number)
    {
        Counter = number;
    }
    private void Open()
    {
        isOpen = true;
        transform.DOMoveX(1550, 1);
    }
    private void Close()
    {
        isOpen = false;
        transform.DOMoveX(2500, 1);
    }
}
