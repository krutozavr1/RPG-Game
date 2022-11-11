using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{
    [SerializeField] LayerMask wallLayer;

    void Update()
    {
        ControlScale();
    }

    private void ControlScale()
    {
        Vector3 scale = transform.localScale;
        scale.Set(GetDistanceToNearestObj(), 1, 1);
        transform.localScale = scale;
        
    }

    private float GetDistanceToNearestObj()
    {
        float distToObj = 16;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right, 16, wallLayer);
        if(hit)
        {
           distToObj = Vector2.Distance(transform.position, hit.point);
        }
        return distToObj / 15;
    }
}
