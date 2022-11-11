using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableEntity : MonoBehaviour
{
    [SerializeField]GameObject entityPrefab;
    GameObject curObj;
    public static bool enemiesAreSlown = false;

    private void Start()
    {
        RespawnEntity();
        
    }

    private void Update()
    {

    }

    public void RespawnEntity()
    {
        Destroy(curObj);
        curObj = Instantiate(entityPrefab, transform.position, Quaternion.identity);
        TrySlowEnemy();
    }

    public void TrySlowEnemy()
    {
        if ((enemiesAreSlown) && (curObj != null))
        {
            PatrollingEntity enemy;
            if (curObj.TryGetComponent<PatrollingEntity>(out enemy))
            {
                enemy.SlowItself();
            }
        }
    }

}
