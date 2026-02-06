using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;

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
            
            if (FeederObject != null)
            {
                if (lastObject != objectHit)
                {
                    SeedClose();
                }
            }

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
        pos1.DOAnchorPos3DX(270, 1);
       // Panel.transform.DOMoveX(1550, 1);
    }
    private void Close()
    {
        pos1.DOAnchorPos3DX(570, 1);
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
