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
    [SerializeField] private GameObject PanelCreate; 
    [SerializeField] private GameObject[] _Feeders;
    [SerializeField] private GameObject Camera;

    private float[] costs = { 0f, 5f, 10f, 15f };
    private int Counter = -1;
    private bool isOpen = false;
    public bool isTargeted = false;
    private RectTransform posCreate;

    private void Awake()
    {
        ButtonFeeder1.onClick.AddListener(() => feederCounter(1));
        ButtonFeeder2.onClick.AddListener(() => feederCounter(2));
        ButtonFeeder3.onClick.AddListener(() => feederCounter(3));
        CreateFeeder.onClick.AddListener(Create);
        CloseMenu.onClick.AddListener(Close);

        posCreate = PanelCreate.GetComponent<RectTransform>();
    }
    private void Update()
    {
        if (Camera.GetComponent<MoneyLogic>().money < costs[Counter] || Counter == -1)
        {
            CreateFeeder.interactable = false;
        }
        else
        {
            CreateFeeder.interactable = true;
        }
    }
    private void Create() 
    {
        if (isTargeted)
        {
            Debug.Log($"Создана кормушка {Counter}");
            Instantiate(_Feeders[Counter - 1], transform.parent);
            Camera.GetComponent<MoneyLogic>().money -= costs[Counter];
            Close();
            Counter = -1;
            Destroy(gameObject);
        }
    }
    private void feederCounter(int number)
    {
        Counter = number;
    }
    private void Open()
    {
        posCreate.DOAnchorPos3DX(570, 1);
        // Panel.transform.DOMoveX(1550, 1);
    }
    private void Close()
    {
        posCreate.DOAnchorPos3DX(1500, 1);
        // Panel.transform.DOMoveX(2500, 1);
    }
}
