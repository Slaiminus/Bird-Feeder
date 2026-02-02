using UnityEngine;

public class TreeTeleporter : MonoBehaviour //Скрипт закреплён на Camera Center
{

    [SerializeField] private string TreeTag;
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
                Debug.Log("Tree Hitted");
            }
        }
    }
}
