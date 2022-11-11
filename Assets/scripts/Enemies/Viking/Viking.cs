using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viking : Enemy
{

    /*[SerializeField]
    List<GameObject> rewards = new List<GameObject>();
    string curAttackType = string.Empty;
    int hammerDmg = 25, swordDmg = 35, spinDmg = 18;
    bool isBattleCrying = false;
    protected override void SetDifferentVariables()
    {
        chasingSpeed = .8f;
        patrolingSpeed = .6f;
    }

    public override void GetDamage(float dmg, bool canStagger = true)
    {
        hp -= dmg;
        healthBar.ChangeSliderValue(hp);
        if ((hp <= 0) && (!isDead))
        {
            isDead = true;
            speed = 0;
            anim.SetTrigger("Die");
        }
        else if((hp < 50) && (!isBattleCrying))
        {
            anim.SetTrigger("BattleCry");
        }
        if(canStagger)
        {
            anim.SetTrigger("GetHit");

        }
    }

    public void SetAttackType(string type)
    {
        if(!isAttacking)
        {

            curAttackType = type;
            StartAttack();
            if(type == "sword")
            {
                AttackWithSword();
            }
            else if(type == "hammer")
            {
                AttackWithHammer();
            }
            else if(type == "spin")
            {
                AttackWithSpin();
            }
        }
    }

    void AttackWithSword()
    {
        canMove = false;
        rb.velocity = Vector2.zero;

        anim.SetTrigger("SwordAttack");
    }

    void AttackWithHammer()
    {
        canMove = false;
        rb.velocity = Vector2.zero;
        anim.SetTrigger("HammerAttack");


    }

    void AttackWithSpin()
    {
        speed += 1;
        anim.SetTrigger("SpinningAttack");

    }

    public void HitPlayer(GameObject player)
    {
        if(curAttackType == "hammer")
        {
            player.GetComponent<Player>().GetDamage(hammerDmg);
            player.GetComponent<Player>().GetKnockback(10, (player.transform.position - transform.position).normalized);
        }
        else if(curAttackType == "sword")
        {
            player.GetComponent<Player>().GetDamage(swordDmg);
            player.GetComponent<Player>().GetKnockback(5, (player.transform.position - transform.position).normalized);
        }
        else if(curAttackType == "spin")
        {
            player.GetComponent<Player>().GetDamage(spinDmg);
            player.GetComponent<Player>().GetKnockback(6, (player.transform.position - transform.position).normalized);
        }
    } 
    
    public void HitEnemy(GameObject enemy)
    {
        if(curAttackType == "hammer")
        {
            enemy.GetComponent<Enemy>().GetDamage((int)(hammerDmg * .5f));
            enemy.GetComponent<Enemy>().GetKnockback(10, (enemy.transform.position - transform.position).normalized);
        }
        else if(curAttackType == "sword")
        {
            enemy.GetComponent<Enemy>().GetDamage((int)(swordDmg * .5f));
            enemy.GetComponent<Enemy>().GetKnockback(5, (enemy.transform.position - transform.position).normalized);
        }
        else if(curAttackType == "spin")
        {
            enemy.GetComponent<Enemy>().GetDamage((int)(spinDmg * .5f));
            enemy.GetComponent<Enemy>().GetKnockback(6, (enemy.transform.position - transform.position).normalized);
        }
    }

    public void DropReward()
    {
        GameObject reward = Instantiate(rewards[Random.Range(0, rewards.Count)], transform.position, Quaternion.identity);
    }

    IEnumerator StartBattleCry()
    {
        isBattleCrying = true;
        canMove = false;
        rb.velocity = Vector2.zero;

        yield return new WaitForSeconds(1.1f);

        canMove = true;
        GetDamage(-30);
        swordDmg = (int)(swordDmg * 1.5f);
        hammerDmg = (int)(hammerDmg * 1.5f);
        spinDmg = (int)(spinDmg * 1.5f);
        speed += 1;
        GetComponent<SpriteRenderer>().color = new Color(1, .7f, .7f);

        yield return new WaitForSeconds(5);

        swordDmg = (int)(swordDmg / 1.5f);
        hammerDmg = (int)(hammerDmg / 1.5f);
        spinDmg = (int)(spinDmg / 1.5f);
        speed = chasingSpeed;
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);

    }*/

}
