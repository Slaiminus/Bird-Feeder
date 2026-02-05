using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class MoneyLogic : MonoBehaviour
{
    [SerializeField] TMP_Text moneyText;
    [SerializeField] Button TestAddButton;
    [SerializeField] Button TestRemoveButton;

    public float money = 0f;

    private void Awake()
    {
        TestAddButton.onClick.AddListener(Addd);
        TestRemoveButton.onClick.AddListener(Removee);
    }
    private void Update()
    {
        moneyText.text = $"Δενόγθ: {Convert.ToString(money)}";
    }

    private void Addd()
    {
        money++;
    }

    private void Removee()
    {
        money--;
    }
}
