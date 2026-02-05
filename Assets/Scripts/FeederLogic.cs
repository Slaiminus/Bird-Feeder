using DG.Tweening;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class FeederLogic : MonoBehaviour
{
    [SerializeField] GameObject seeds;

    GameObject currentSeeds;

    private void Update()
    {
    }


    private void SeedsCreate()
    {
        if (currentSeeds == null)
        {
            currentSeeds = Instantiate(seeds);
        }
    }

    private void SeedsReduce()
    {
        if (currentSeeds != null)
        {
            currentSeeds.transform.DOScaleY(transform.localScale.y - 0.5f, 1).OnComplete(() =>
            {
                if (currentSeeds.transform.localScale.y <= 0)
                {
                    // TODO: сделать остатки семян
                    Destroy(currentSeeds);
                }
            });
        }
    }
}
