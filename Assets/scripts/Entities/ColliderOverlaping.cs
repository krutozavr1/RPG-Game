using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOverlaping : MonoBehaviour
{

    public bool isOverlapping = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isOverlapping = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverlapping = true;

    }
}
