using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 5);
    }

   void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {
          //  collision.GetComponent<Enemy>().GetDamage(10);
            Destroy(gameObject);
        }
    }
}
