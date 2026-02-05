using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button closeGame;
    void Start()
    {
        backButton.onClick.AddListener(returnToStart);
        closeGame.onClick.AddListener(CloseGame);
    }
    private void returnToStart()
    {
        SceneManager.LoadScene(1);
    }

    private void CloseGame()
    {
        Application.Quit();
    }
}

