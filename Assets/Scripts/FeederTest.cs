using System;
using System.Diagnostics.CodeAnalysis;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FeederTest : MonoBehaviour
{
    [SerializeField] private Button createFeeder;
    [SerializeField] private FeederAppear script;
    void Start()
    {
        createFeeder.onClick.AddListener(FeederActivate);
    }

    private void FeederActivate()
    {
        createFeeder.interactable = false;
        script.enabled = true;
    }
}
