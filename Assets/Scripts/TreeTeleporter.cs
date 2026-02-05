using DG.Tweening;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.Rendering.DebugUI;

public class TreeTeleporter : MonoBehaviour //Скрипт закреплён на Camera Center
{
    [SerializeField] private string TreeTag;
    [SerializeField] private string FeederTag;
    [SerializeField] private string GhostTag;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject Panel;

    // private FeederCreator feederCreator;
    private GameObject objectHit;
    private GameObject lastObject;
    private GameObject FeederObject;
    private RectTransform pos1;
    private RectTransform seedPos;

    private void Awake()
    {
        pos1 = Panel.GetComponent<RectTransform>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Teleporter();
        }
    }
    void Teleporter()
    {
        if (EventSystem.current != null && EventSystem.current.IsPointerOverGameObject())
            return;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (lastObject != null)
            {
                if (lastObject.GetComponent<FeederCreator>() != null)
                {
                    lastObject.GetComponent<FeederCreator>().isTargeted = false;
                }
            }
            if (objectHit != null)
            {
                lastObject = objectHit;
            }
            objectHit = hit.collider.gameObject;

            if (objectHit.CompareTag(TreeTag))
            {
                transform.DOMove(objectHit.transform.position + new Vector3(0, -3, 0), moveSpeed);
            }

            if (objectHit.CompareTag(FeederTag))
            {
                transform.DOMove(objectHit.transform.position, moveSpeed);
                FeederObject = objectHit;
                SeedOpen();
            }
            else
            {
                if (FeederObject != null)
                {
                    SeedClose();
                }
            }

            if (objectHit.CompareTag(GhostTag))
            {
                transform.DOMove(objectHit.transform.position, moveSpeed);
                objectHit.GetComponent<FeederCreator>().isTargeted = true;
                Open();
            }
            else
            {
                Close();
            }
        }
    }

    private void Open()
    {
        pos1.DOAnchorPos3DX(570, 1);
       // Panel.transform.DOMoveX(1550, 1);
    }
    private void Close()
    {
        pos1.DOAnchorPos3DX(1500, 1);
       // Panel.transform.DOMoveX(2500, 1);
    }
    private void SeedOpen()
    {
        FeederObject.GetComponent<FeederLogic>().Open();
    }

    private void SeedClose()
    {
        FeederObject.GetComponent<FeederLogic>().Close();
    }
}
