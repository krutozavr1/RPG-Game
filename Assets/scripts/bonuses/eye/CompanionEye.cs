using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompanionEye : Bonus
{

    [SerializeField]
    GameObject bulletPrefab;
    int bulletSpeed = 2;
    bool looksUp = false, looksRight = false;
    SpriteRenderer spriteRenderer;
    PlayerGameMechanics mechs;

    void Start()
    {
        mechs = FindObjectOfType<PlayerGameMechanics>();
        InvokeRepeating(nameof(ShootTheNearestEnemy), 1, 1.5f);
        InvokeRepeating(nameof(LookAtTheNearestEnemy), 1, .5f);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    Transform GetClosestEnemy(Enemy[] enemies)
    {
        Transform tMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (Enemy t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                tMin = t.transform;
                minDist = dist;
            }
        }
        return tMin;
    }

    void ShootTheNearestEnemy()
    {

    }

    void LookAtTheNearestEnemy()
    {
        
    }

    public override void UseBonus()
    {
        GameObject eye =  Instantiate(gameObject, Vector3.zero, Quaternion.identity);
        eye.transform.SetParent(FindObjectOfType<Player>().transform.GetChild(1));
    }
}
