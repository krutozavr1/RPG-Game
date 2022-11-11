using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEntitiesGenerator : MonoBehaviour
{
    protected int maxQuantityOfEntities, minQuantityOfEntities, averageQuantityOfEntities, avalibleQuantity = 0;
    protected Vector2 minPos, maxPos;
    [SerializeField]
    protected List<GameObject> entityPrefabs = new List<GameObject>();


    void Update()
    {
        
    }

    public void SetRoomMetrics(Vector3 bottomBlock, Vector3 topBlock, float area = 0)
    {
        minPos = new Vector2(Mathf.Min(bottomBlock.x, topBlock.x), Mathf.Min(bottomBlock.y, topBlock.y));
        maxPos = new Vector2(Mathf.Max(bottomBlock.x, topBlock.x), Mathf.Max(bottomBlock.y, topBlock.y));
        SetQuantityOfEntities(area);
    }

  

    protected virtual void SetQuantityOfEntities(float area)
    {

        if (area < 250)
        {
            avalibleQuantity = minQuantityOfEntities;
        }
        else if (area < 280)
        {
            avalibleQuantity = averageQuantityOfEntities;
        }
        else if (area > 280)
        {
            avalibleQuantity = maxQuantityOfEntities;
        }
        GenerateEntities();
    }

    
    protected virtual void GenerateEntities()
    {
        for (int i = 0; i < avalibleQuantity; i++)
        {
            Collider2D[] results = new Collider2D[20];
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Default"));
            //cheking if gameobject overlaping something
            GameObject entity = Instantiate(entityPrefabs[Random.Range(0, entityPrefabs.Count)], new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
            entity.GetComponent<BoxCollider2D>().size *= 3;
            while (!(entity.GetComponent<BoxCollider2D>().OverlapCollider(filter, results) == 0))
            {
                Destroy(entity);
                entity = Instantiate(entityPrefabs[Random.Range(0, entityPrefabs.Count)], new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
                entity.GetComponent<BoxCollider2D>().size *= 3;

            }
            entity.GetComponent<BoxCollider2D>().size /= 3;
            entity.transform.parent = gameObject.transform;
        }
    }
}
