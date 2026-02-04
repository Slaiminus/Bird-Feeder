using DG.Tweening;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TreeTeleporter : MonoBehaviour //Скрипт закреплён на Camera Center
{
    [SerializeField] private string TreeTag;
    [SerializeField] private string FeederTag;
    [SerializeField] private float moveSpeed;
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
            if (hit.transform.CompareTag(TreeTag))
            {
                transform.DOMove(hit.transform.position + new Vector3(0, -3, 0), moveSpeed);
            }

            if (hit.transform.CompareTag(FeederTag))
            {
                transform.DOMove(hit.transform.position, moveSpeed);
            }
        }
    }
}
