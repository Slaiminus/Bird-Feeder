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
            if (objectHit != null)
            {
                lastObject = objectHit;
            }
            objectHit = hit.collider.gameObject;
            

            if (objectHit.CompareTag(TreeTag))
            {
                transform.DOMove(objectHit.transform.position + new Vector3(0, -3, 0), moveSpeed);
                lastObject.GetComponent<FeederCreator>().isTargeted = false;
                Close();
            }

            if (objectHit.CompareTag(FeederTag))
            {
                transform.DOMove(objectHit.transform.position, moveSpeed);
                lastObject.GetComponent<FeederCreator>().isTargeted = false;
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
        Panel.transform.DOMoveX(1550, 1);
    }
    private void Close()
    {
        Panel.transform.DOMoveX(2500, 1);
    }
}
