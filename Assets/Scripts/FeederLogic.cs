using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
// using static UnityEngine.Rendering.DebugUI;

public class FeederLogic : MonoBehaviour
{
    [SerializeField] private GameObject seeds;
    [SerializeField] private GameObject thePanel;
    [SerializeField] private float earnAmount;
    private TMP_Text seedText;
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
        seedText = panel.transform.Find("SeedText").GetComponent<TMP_Text>();
        // seedsCounter = panel.transform.Find("SeedProgress").GetComponent<Image>();  - пока не работает :(

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
            // seedsCounter.fillAmount = 2 / currentSeeds.transform.localScale.y;
            seedText.text = $"{currentSeeds.transform.localScale.y * 50}%";
        }
        else
        {
            seedText.text = $"Пусто";
            //seedsCounter.fillAmount = 0;
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
