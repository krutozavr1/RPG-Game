using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : Weapon
{
    Rigidbody2D rb;
    bool isThrown = false, isExploding = false;
    [SerializeField]
    float speed;
    int quantityOfCollisions = 0;

    void Start()
    {
    }

    protected override void SetDifferentVariables()
    {
        timePassed = 0;
        cd = 1.5f;
        print(GetComponent<CircleCollider2D>());
        print(GameObject.Find("player").GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(GetComponent<CircleCollider2D>(), GameObject.Find("player").GetComponent<BoxCollider2D>());
    }

    protected override void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && (cd <= timePassed) && (!isThrown))
        {
            //StartCoroutine(playerMove.LowerSpeed(.8f));
            ThrowGrenade();

        }
        timePassed += Time.deltaTime;

        if(quantityOfCollisions >= 3)
        {
            Explode();
        }

        if((isThrown) && (!isExploding))
        {
            transform.Rotate(0, 0, 10);
        }
    }

    void ThrowGrenade()
    {
        Invoke(nameof(Explode), 5);
        Invoke(nameof(CreateNewGrenade), .2f);
        anim.SetTrigger("throw");
        isThrown = true;
        Vector3 mousePos = Input.mousePosition;
        Vector3 direction = (GameManager.instance.cam.ScreenToWorldPoint(mousePos) - transform.position).normalized;
        transform.parent = null;
        SetRigidBodyUp();
        rb.velocity = direction.normalized * speed;
    }

    void SetRigidBodyUp()
    {
        rb = gameObject.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void CreateNewGrenade()
    {
        GameObject grenade = Instantiate(GameManager.instance.grenadePrefab, Vector3.zero, Quaternion.identity);
        grenade.transform.parent = GameObject.Find("player").transform.GetChild(0) ;
        grenade.transform.localPosition = startPos;
        grenade.transform.rotation = Quaternion.Euler(startRot);
    }

    void Explode()
    {
        if(rb != null)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        anim.SetTrigger("explode");
        isExploding = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "enemy") && (!collision.collider.isTrigger) && (isThrown))
        {
            Explode();
        }
        else if((isThrown) && (!collision.collider.isTrigger))
        {
           // dmg = (int)(dmg * 1.75f);
            quantityOfCollisions++;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((isExploding) && (collision.tag == "enemy"))
        {
            HitEnemy(collision.gameObject);
        }
    }

    void HitEnemy(GameObject enemy)
    {
        //enemy.GetComponent<Enemy>().GetDamage(dmg);
       // enemy.GetComponent<Enemy>().GetKnockback(knockbackVal, (enemy.transform.position - transform.position).normalized);
    }

    void DestroySelf()
    {
        Destroy(gameObject);
    }
}
