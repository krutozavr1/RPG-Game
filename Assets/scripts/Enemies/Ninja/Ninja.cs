using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ninja : Enemy
{
   /* string attackType;
    protected override void SetDifferentVariables()
    {
        chasingSpeed = 5;
        patrolingSpeed = 2;
    }


    public void SetAttackType(string type)
    {
        attackType = type;
        canMove = false;
        rb.velocity = Vector2.zero;
        if (type == "sword")
        {
            AttackWithSword();
        }
        else if(type == "explosion")
        {
            AttackWithExplosion();
        }

    }


    void AttackWithSword()
    {
        anim.SetTrigger("attack");
    }

    void AttackWithExplosion()
    {
        GetDamage(7);
        anim.SetTrigger("explosiveAttack");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if((isAttacking) && (collision.tag == "Player"))
        {
            if(attackType == "sword")
            {
                collision.GetComponent<Player>().GetDamage(25);
                collision.GetComponent<Player>().GetKnockback(3, dirToPlayer);
            }
            else if(attackType == "explosive")
            {
                collision.GetComponent<Player>().GetDamage(35);
                collision.GetComponent<Player>().GetKnockback(8, dirToPlayer);
            }
        }
    }

    public void HitObject(GameObject obj)
    {
        if (attackType == "sword")
        {
            if (obj.TryGetComponent(out Player player))
            {
                player.GetDamage(25);
                player.GetKnockback(1, dirToPlayer);

            }
            else
            {
                obj.GetComponent<Enemy>().GetDamage(12);
                obj.GetComponent<Enemy>().GetKnockback(2, (obj.transform.position - transform.position).normalized);
            }
        }
        else if (attackType == "explosion")
        {
            if (obj.TryGetComponent(out Player player))
            {
                player.GetDamage(35);
                player.GetKnockback(8, dirToPlayer);

            }
            else
            {
                obj.GetComponent<Enemy>().GetDamage(20);
                obj.GetComponent<Enemy>().GetKnockback(6, (obj.transform.position - transform.position).normalized);
            }
        }
        
    }

    void SelfDestruct()
    {
        attackType = "explosion";
    }*/
}
