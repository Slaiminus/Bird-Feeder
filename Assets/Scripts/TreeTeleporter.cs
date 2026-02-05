using DG.Tweening;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
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
    private RectTransform pos1;

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
                Close();
            }

            if (objectHit.CompareTag(FeederTag))
            {
                transform.DOMove(objectHit.transform.position, moveSpeed);
                Close();
            }

            if (objectHit.CompareTag(GhostTag))
            {
                transform.DOMove(objectHit.transform.position, moveSpeed);
                objectHit.GetComponent<FeederCreator>().isTargeted = true;
                Open();
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
}
