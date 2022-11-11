using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTile : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "waterFallCollider")
        {
            if(collision.transform.parent.TryGetComponent<PhisicalEntity>(out var entity))
            {
                entity.Die();
            }
        }
    }
}
