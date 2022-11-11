using Pathfinding.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBattleTrigger : Trigger
{
    [SerializeField] GameObject door;
    [SerializeField] Golem golem;

    private void Update()
    {
        if(golem == null)
        {
            Destroy(gameObject);
        }
        if(golem.BattleHasStarted)
        {
            door.SetActive(true);
        }
        else
        {
            door.SetActive(false);
        }
    }

    public override void ActivateEvent()
    {
        if(!golem.BattleHasStarted)
        {
            FindObjectOfType<Golem>().StartBattle();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ActivateEvent();
        }
    }
}
