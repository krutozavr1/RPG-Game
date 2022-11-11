using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyTypePrefab;
    GameObject enemy;

    void Start()
    {
        enemy = Instantiate(enemyTypePrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
