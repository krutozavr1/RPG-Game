using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySlowSpell : InventoryBonus
{


    public override void UseItem()
    {
        RespawnableEntity.enemiesAreSlown = true;
        foreach(RespawnableEntity enemy in FindObjectsOfType<RespawnableEntity>())
        {
            enemy.TrySlowEnemy();
        }
    }
}
