using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrowingKnife : Weapon
{
    GameObject knifePrefab;
    bool isThrown = false;
    Rigidbody2D rb;
    float speed = 3.5f;
    protected override void SetDifferentVariables()
    {
        rb = GetComponent<Rigidbody2D>();
        knifePrefab = GameManager.instance.knifePrefab;
    }
    protected override void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && (!isThrown))
        {
            ThrowKnife();
        }
        

    }

    void ThrowKnife()
    {
        isThrown = true;
        Invoke(nameof(CreateNewKnife), .25f);
        transform.parent = null;
        anim.SetTrigger("isThrown");
        Vector3 mousePos = Input.mousePosition;
        Vector3 direction = (GameManager.instance.cam.ScreenToWorldPoint(mousePos) - transform.position).normalized;
        rb.velocity = direction.normalized * speed;
        Destroy(gameObject, 7);
    }

    void CreateNewKnife()
    {
        GameObject knife =  Instantiate(knifePrefab, startPos, Quaternion.Euler( startRot));
        knife.transform.SetParent(GameManager.instance.player.transform);
        knife.transform.localPosition = startPos;
        knife.transform.rotation = Quaternion.Euler(startRot);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isThrown)
        {
            if((collision.tag == "obstacle") || (collision.tag == "enemy"))
            {
                if (collision.tag == "enemy")
                {

                    Vector3 direction = (collision.transform.position - transform.position).normalized;
                    //collision.GetComponent<Enemy>().GetDamage(dmg);
                }
                anim.speed = 0;
                rb.constraints = RigidbodyConstraints2D.FreezeAll;
                transform.parent = collision.transform;
                Destroy(gameObject, 3);
                Destroy(GetComponent<BoxCollider2D>());
            }
        }
    }
}
