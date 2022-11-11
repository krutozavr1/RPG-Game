using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameCollectablesGenerator : GameEntitiesGenerator
{

    [SerializeField]
    GameObject shopFlagPrefab;
    void Awake()
    {
        maxQuantityOfEntities =2;
        averageQuantityOfEntities = 1;
        minQuantityOfEntities = 0;
    }

    void Update()
    {
    }


    public void SpawnShop()
    {

        Collider2D[] results = new Collider2D[20];
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Default"));
        //cheking if gameobject overlaping something
        GameObject entity = Instantiate(shopFlagPrefab, new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
        entity.GetComponent<BoxCollider2D>().size *= 3;
        while (!(entity.GetComponent<BoxCollider2D>().OverlapCollider(filter, results) == 0))
        {
            Destroy(entity);
            entity = Instantiate(shopFlagPrefab, new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
            entity.GetComponent<BoxCollider2D>().size *= 3;

        }
        entity.GetComponent<BoxCollider2D>().size /= 3;

        entity.transform.parent = gameObject.transform;
    }
}
