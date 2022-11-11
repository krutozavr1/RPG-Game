using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy
{


   /*protected override void SetDifferentVariables()
    {
        chasingSpeed = 1.5f;
        patrolingSpeed = 1f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        if ((collision.gameObject.tag == "Player") && (!isDead))
        {
            Explode();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (((collision.tag == "Player") || (collision.tag == "enemy")) && (isDead))
        {

            Attack(collision.gameObject);
        }
    }

    public override void GetDamage(float dmg, bool canStagger = true)
    {

        hp -= dmg;
        healthBar.ChangeSliderValue(hp);
        if (hp <= 0)
        {
            Explode();
        }

        

    }

    protected override void Attack(GameObject target)
    {


        if (target.tag == "Player")
        {
            target.GetComponent<Player>().GetDamage(20);
            target.GetComponent<Player>().GetKnockback(7, dirToPlayer);
        }
        else if(target.tag == "enemy")
        {
            target.GetComponent<Enemy>().GetDamage(20);
            target.GetComponent<Enemy>().GetKnockback(7, ((target.transform.position - transform.position).normalized));
        }
    }

    void Explode()
    {
        isDead = true;
        speed = 0;
        anim.SetTrigger("Explode");
    }*/
}
