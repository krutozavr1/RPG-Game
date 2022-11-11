using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : GameEntitiesGenerator
{/*
    public List<GameObject> enemies = new List<GameObject>();

    [SerializeField]
    GameObject spawnMarkPrefab, miniBossSpawnMarkPrefab;
    GameObject mark;
    public int avalibleQuantityOfWaves;
    int waveCountDown, curAvalibleQuantity;

    void Awake()
    {
        minQuantityOfEntities = 10;
        averageQuantityOfEntities = 13;
        maxQuantityOfEntities = 16;

    }

    protected override void GenerateEntities()
    {
        StartCoroutine(GenerateEnemies());
    }

    protected override void SetQuantityOfEntities(float area)
    {
        if (area < 250)
        {
            avalibleQuantity = minQuantityOfEntities;
            waveCountDown = 6;
            avalibleQuantityOfWaves = 4;
        }
        else if (area < 280)
        {
            avalibleQuantity = averageQuantityOfEntities;
            waveCountDown = 9;
            avalibleQuantityOfWaves = 4;
        }
        else if (area > 280)
        {
            avalibleQuantity = maxQuantityOfEntities;
            waveCountDown = 12;
            avalibleQuantityOfWaves = 3;
        }
        GenerateEntities();
    }

    IEnumerator GenerateEnemies()
    {
        while (avalibleQuantityOfWaves > 0)
        {

            GenerateEnemyWave();
            avalibleQuantityOfWaves--;
            yield return new WaitForSeconds(waveCountDown);
        }

    }
    public void GenerateEnemyWave()
    {
        enemies.Clear();
        curAvalibleQuantity = avalibleQuantity;
        SpanwMark();
    }


    void SpanwMark()
    {
        if (curAvalibleQuantity > 1)
        {

            Collider2D[] results = new Collider2D[5];
            ContactFilter2D filter = new ContactFilter2D();
            filter.SetLayerMask(LayerMask.GetMask("Default"));
            //cheking if gameobject overlaping something
            mark = Instantiate(spawnMarkPrefab, new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);
            while (!(mark.GetComponent<CircleCollider2D>().OverlapCollider(filter, results) == 0))
            {
                Destroy(mark);
                mark = Instantiate(spawnMarkPrefab, new Vector3(Random.Range(minPos.x, maxPos.x), Random.Range(minPos.y, maxPos.y), 0), Quaternion.identity);

            }
            mark.GetComponent<SpriteRenderer>().enabled = true;
            StartCoroutine(SpawnEnemy());
        }
        else
        {
            return;
        }
    }

    IEnumerator SpawnEnemy()
    {
        GameObject curMark = mark;
        GameObject enemy = entityPrefabs[Random.Range(0, entityPrefabs.Count)];
        while (enemy.GetComponent<Stats>().enemyUnitCost > curAvalibleQuantity)
        {
            enemy = entityPrefabs[Random.Range(0, entityPrefabs.Count)];
        }
        curAvalibleQuantity -= enemy.GetComponent<Stats>().enemyUnitCost;
        SpanwMark();

        yield return new WaitForSeconds(Random.Range(1, 2));

        Destroy(curMark);
        GameObject trueEnemy =  Instantiate(enemy, curMark.transform.position, Quaternion.identity);
        if(enemy.name == "ciklop")
        {
            trueEnemy.GetComponent<Ciklop>().SetRoomMetricsForTP(minPos, maxPos);
        }

        enemies.Add(trueEnemy);
        trueEnemy.transform.parent = gameObject.transform;
    }

    */
    
}
