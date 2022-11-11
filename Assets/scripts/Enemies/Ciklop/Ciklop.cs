using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ciklop : Enemy
{
   /* [SerializeField]
    GameObject portalPrefab;
    GameObject player;
    float spellCastCD = 2, tpCD = 0;
    bool isMeleeAttacking = false, isTPing = false;
    Vector2 minPosForTp, maxPosForTP;
    void Start()
    {
        player = GameObject.Find("player");
        isFacingRight = false;

    }

    protected override void Update()
    {
        spellCastCD += Time.deltaTime;
        tpCD += Time.deltaTime;
        if ((spellCastCD >= 5) && (!isTPing))
        {
            CastSpell();
        }
        if((tpCD >= 11))
        {
            StopAllCoroutines();
            tpCD = 0;
            StartCoroutine(Teleport());
        }
        LookAtPlayer();
        rb.velocity = Vector2.zero;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if ((!isMeleeAttacking) && (!isAttacking))
            {
                anim.SetTrigger("meleeAttack");
            }
            else if (isMeleeAttacking)
            {
                MeleeAttack();
            }
        }
    }

    void MeleeAttack()
    {
        player.GetComponent<Player>().GetDamage(30);
        player.GetComponent<Player>().GetKnockback(8, (player.transform.position - transform.position).normalized);
    }

    void CastSpell()
    {
        isAttacking = true;
        anim.SetTrigger("castSpell");
    }

    IEnumerator SummonPortals()
    {

        GameObject portal;
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            spellCastCD = 0;
            yield return new WaitForSeconds(1.2f);
            if (Random.Range(0, 2) == 0)
            {
                portal = Instantiate(portalPrefab, player.transform.position + new Vector3(0, .4f), Quaternion.identity);
            }
            else
            {
                portal = Instantiate(portalPrefab, player.transform.position - new Vector3(0, .4f), Quaternion.Euler(0, 0, 180));
            }
        }
        EndSummonning();

    }

    void EndSummonning()
    {
        anim.SetTrigger("endSummonning");
        spellCastCD = 0;
        isAttacking = false;
    }

    void StartMeleeAttack()
    {
        isMeleeAttacking = true;
    }

    void EndMeleeAttack()
    {
        isMeleeAttacking = false;
    }

   

    public void SetRoomMetricsForTP(Vector2 minPos, Vector2 maxPos)
    {
        minPosForTp = minPos;
        maxPosForTP = maxPos;
    }

    IEnumerator Teleport()
    {
        isAttacking = false;

        isTPing = true;
        anim.SetTrigger("TP");
        yield return new WaitForSeconds(1.6f);

        transform.position = new Vector3(Random.Range(minPosForTp.x, maxPosForTP.x), Random.Range(minPosForTp.y, maxPosForTP.y), 0);
        isTPing = false;
        tpCD = 0;
        anim.ResetTrigger("endSummonning");
        anim.ResetTrigger("castSpell");
        anim.ResetTrigger("meleeAttack");
    }*/
}   

    

