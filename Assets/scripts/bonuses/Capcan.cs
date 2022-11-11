using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capcan : SecondaryWeapon
{

    bool grabedEnemy = false;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((collision.tag == "enemy") && (!grabedEnemy))
        {
            StartCoroutine(GrabEnemy(collision.gameObject));
        }
    }

    IEnumerator GrabEnemy(GameObject enemy)
    {
        grabedEnemy = true;
        enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;

        yield return new WaitForSeconds(3);

        enemy.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

        Destroy(gameObject);
    }
}
