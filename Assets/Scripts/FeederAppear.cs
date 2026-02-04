using UnityEngine;

public class FeederAppear : MonoBehaviour
{
    [SerializeField] private GameObject Feeder;
    void Start()
    {
        Feeder.SetActive(true);
    }
}
