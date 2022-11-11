using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Necromancer : Enemy
{
    [SerializeField] List<GameObject> enemiesForSpawn;
    [SerializeField] GameObject powerSkullPrefab, spawnPointForSkull, spawnPointForEnemies;
    [SerializeField]float cdForEnemy, cdForSkull;
    List<GameObject> spawnedEntities = new List<GameObject>();
    float skullTime, enemyTime;
    bool isSpawning = false, seesPlayer = false;

    private void Awake()
    {
        lineOfSight = GetComponentInChildren<LineOfSight>();
    }

    protected override void Update()
    {
        isFacingRight = transform.right == new Vector3(1, 0, 0);
        seesPlayer = lineOfSight.seesPlayer;
        if(seesPlayer)
        {
            LookAtPlayer(false);
            if(!isSpawning)
            {
                if(skullTime > cdForSkull)
                {
                    StartSpawning("SpawnSkull");
                }
                if (enemyTime > cdForEnemy)
                {
                    StartSpawning("SpawnEnemy");
                }
            }

            skullTime += Time.deltaTime;
            enemyTime += Time.deltaTime;
        }
    }

    private void StartSpawning(string nameOfTrigger)
    {
        anim.SetTrigger(nameOfTrigger);
        isSpawning = true;
    }

    private void SpawnPowerSkull()
    {
        isSpawning = false;
        GameObject skull = Instantiate(powerSkullPrefab, spawnPointForSkull.transform.position, transform.rotation);
        spawnedEntities.Add(skull);
        skullTime = 0;


    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemiesForSpawn[Random.Range(0, enemiesForSpawn.Count)], spawnPointForEnemies.transform.position, transform.rotation);
        enemy.GetComponent<Enemy>().isFacingRight = isFacingRight;
        spawnedEntities.Add(enemy);
        isSpawning = false;
        enemyTime = 0;

    }

    private void OnDestroy()
    {
        foreach(GameObject obj in spawnedEntities)
        {
            Destroy(obj);
        }
    }
}
