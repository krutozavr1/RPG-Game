using PathCreation;
using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Golem : PhisicalEntity
{
    [SerializeField]SliderController bossHpBar;
    [SerializeField] List<Transform> navigationPoints = new List<Transform>();
    [SerializeField] GameObject projectileCirclePrefab, aimingProjectilePrefab, projectileSpawnPoint, laser, tpHand, circleAroundPlayer, playerLaser;
    Animator anim;
    AIDestinationSetter destination;
    AIPath pathFinder;
    bool battleHasStarted = false, isAttacking = false;
    Dictionary<string, float> attacks = new Dictionary<string, float>();

    protected override void Start()
    {
        GetAllComponents();
    }

    private void GetAllComponents()
    {
        destination = GetComponent<AIDestinationSetter>();
        healthBar = bossHpBar.GetComponent<SliderController>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        pathFinder = GetComponent<AIPath>();
    }

    private void SetAllAttacks()
    {
        attacks.Clear();
        attacks.Add("CastProjectile", 3);
        attacks.Add("Reinforce", 4);
        attacks.Add("Laser", 5);
        attacks.Add("Summon", 6);
    }

    public void StartBattle()
    {
        SetAllAttacks();
        destination.target = navigationPoints[1];
        healthBar.gameObject.SetActive(true);
        curHp = maxHp;
        healthBar.SetMaxValue(maxHp);
        battleHasStarted = true;
        StartCoroutine(CicleAttacks());

    }
    void Update()
    {
        if(battleHasStarted)
        {
            MoveThroughArena();
        }
        LookAtPlayer();
    }


    private void MoveThroughArena()
    {
        if(Vector2.Distance(transform.position, destination.target.transform.position) < .5f)
        {
            destination.target = navigationPoints[Random.Range(0, navigationPoints.Count)];
        }
    }

    private void CastProjectileCircle()
    {
        GameObject circleCast = Instantiate(projectileCirclePrefab, transform.position, Quaternion.identity);
        attacks["Reinforce"] = Random.Range(5, 8);

    }

    private void CastAimingProjectile()
    {
        
        GameObject aimProj = Instantiate(aimingProjectilePrefab, projectileSpawnPoint.transform.position, Quaternion.identity);
        attacks["CastProjectile"] = Random.Range(4, 6);

    }

    private void StartLaser()
    {
        laser.GetComponent<GolemLaser>().StartLasering(true);
        attacks["Laser"] = Random.Range(5, 8);
        StartCoroutine(FinishAttack(4));
    }

    private void SummonHands()
    {
        StartCoroutine(SummonTpHands());
    }

    private IEnumerator SummonTpHands()
    {
        pathFinder.canMove = false;
        rb.velocity = Vector2.zero;
        for(int i = 0; i < 5; i++)
        {
            GameObject hand = Instantiate(tpHand, transform.position, Quaternion.identity);
            circleAroundPlayer.transform.position = PlayerGameMechanics.instance.transform.position;
            hand.GetComponent<TeleportingHand>().Circle = circleAroundPlayer.GetComponent<PathCreator>();
            hand.GetComponent<TeleportingHand>().PositionAroundPlayer();
            yield return new WaitForSeconds(1f);
        }
        anim.SetTrigger("ReturnToIdle");
        pathFinder.canMove = true;
        attacks["Summon"] = Random.Range(5, 7);
        StartCoroutine(FinishAttack());
    }

    private IEnumerator FinishAttack(float time = 0)//mostly called from anim
    {
        yield return new WaitForSeconds(time);
        isAttacking = false;
    }

    private IEnumerator CicleAttacks()
    {
        List<string> avalibleAttacks = new List<string>();
        while(true)
        {
            avalibleAttacks.Clear();    
            yield return new WaitForSeconds(.5f);
            foreach(var attack in attacks.ToList())
            {
                attacks[attack.Key] = attack.Value - .5f; 
                if(!isAttacking)
                {
                    if(attack.Value <= 0)
                    {
                        avalibleAttacks.Add(attack.Key);
                    }
                }
            }
            if(avalibleAttacks.Count > 0)
            {
                anim.SetTrigger(avalibleAttacks[Random.Range(0, avalibleAttacks.Count)]);
                isAttacking = true;
            }
        }
    }

    private void LookAtPlayer()
    {
        if(!isDead)
        {
            if (PlayerMovement.instance.transform.position.x > transform.position.x)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }
    }

    public bool BattleHasStarted
    {
        get
        {
            return battleHasStarted;
        }
    }

    public void ResetBattle()
    {
        StopAllCoroutines();
        pathFinder.canMove = true;
        isAttacking = false;
        anim.SetTrigger("ReturnToIdle");
        battleHasStarted = false;
        destination.target = null;
        curHp = maxHp;
        healthBar.SetMaxValue(maxHp);
        healthBar.gameObject.SetActive(false);
    }
    public override void Die()
    {
        anim.SetTrigger("Die");
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        isDead = true;
        healthBar.gameObject.SetActive(false);
        GameObject laser = Instantiate(playerLaser, transform.position - new Vector3(0, 1.5f, 0), Quaternion.identity);
        Destroy(this);
    }

}
