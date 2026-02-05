using DG.Tweening;
using System.Collections;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;
// using static UnityEngine.Rendering.DebugUI;

public class FeederLogic : MonoBehaviour
{
    [SerializeField] private GameObject seeds;
    [SerializeField] private GameObject thePanel;
    [SerializeField] private float earnAmount;
    public GameObject panel;
    private GameObject Player;
    private Button GetSeeds;
    private Button CloseButton;
    private Image seedsCounter;
    private RectTransform pos1;

    GameObject currentSeeds;
    [SerializeField] private float minDelay; // Минимальная задержка
    [SerializeField] private float maxDelay; // Максимальная задержка

    private void Awake()
    {
        var canvas = GameObject.Find("Canvas");
        Player = GameObject.Find("Camera Center");
        panel = Instantiate(thePanel, canvas.transform);
        GetSeeds = panel.transform.Find("ReFill").GetComponent<Button>();
        CloseButton = panel.transform.Find("Close").GetComponent<Button>();
        seedsCounter = panel.transform.Find("Image").GetComponent<Image>();

    }
    private void Start()
    {
        GetSeeds.onClick.AddListener(SeedsCreate);
        CloseButton.onClick.AddListener(Close);
        StartCoroutine(DoSomethingRandomly());
    }

    private void Update()
    {
        if (currentSeeds != null) 
        {
            seedsCounter.fillAmount = 2 / currentSeeds.transform.localScale.y;
        }
        else
        {
            seedsCounter.fillAmount = 0;
        }
    }

    IEnumerator DoSomethingRandomly()  // Украл из интернета, простите
    {
        while (true) // Бесконечный цикл
        {
            // Случайное время ожидания
            float randomWait = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(randomWait);
            if (currentSeeds != null)
            {
                if (currentSeeds.transform.localScale.y > 0)
                {
                    SeedsReduce();
                    Debug.Log("Семена Потрачены");
                }
            }
        }
    }

    private void SeedsCreate()
    {
        if (currentSeeds == null)
        {
            currentSeeds = Instantiate(seeds, transform);
        }
        else
        {
            currentSeeds.transform.DOScaleY(2, 1);
        }
    }

    private void SeedsReduce()
    {
        if (currentSeeds != null)
        {
            Player.GetComponent<MoneyLogic>().money += earnAmount;
            currentSeeds.transform.DOScaleY(currentSeeds.transform.localScale.y - 0.5f, 1).OnComplete(() =>
            {
                if (currentSeeds.transform.localScale.y <= 0)
                {
                    // TODO: сделать остатки семян
                    Destroy(currentSeeds);
                }
            });
        }
    }
    public void Close()
    {
        pos1 = panel.GetComponent<RectTransform>();
        pos1.DOAnchorPos3DY(1000, 1);
    }

    public void Open()
    {
        pos1 = panel.GetComponent<RectTransform>();
        pos1.DOAnchorPos3DY(110, 1);
    }
}
