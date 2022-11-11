using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonfireSystem : MonoBehaviour
{
    public static BonfireSystem instance;
    public Bonfire lastActiveBonfire;
    Player player;
    Golem golem;

    void Start()
    {
        golem = FindObjectOfType<Golem>();
        instance = this;
        player = FindObjectOfType<Player>();
    }


    public void RespawnPlayerOnActiveBonfire()
    {
        player.transform.position = lastActiveBonfire.spawnPoint.position;
        player.GetComponent<PlayerGameMechanics>().Respawn();
        
    }

    public void SetActiveBonfire(Bonfire bonfire)
    {
        if ((lastActiveBonfire != null) && (lastActiveBonfire.gameObject.activeInHierarchy))
        {
            lastActiveBonfire.FireNormally();
        }
        lastActiveBonfire = bonfire;
    }

    public void RespawnAllEntities()
    {
        RespawnPlayerOnActiveBonfire();
        foreach(RespawnableEntity entity in FindObjectsOfType<RespawnableEntity>())
        {
            entity.RespawnEntity();
        }
        if(golem)
        {
            golem.ResetBattle();
        }
    }
}
