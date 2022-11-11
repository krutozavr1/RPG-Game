using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBlock : MonoBehaviour
{
    PlayerGameMechanics mechs;
    GameObject exitBlock;
    BasicRoomGenerator room;
    void Start()
    {
        mechs = FindObjectOfType<PlayerGameMechanics>();
        exitBlock = transform.GetChild(0).gameObject;
        room = transform.parent.GetComponent<BasicRoomGenerator>();
    }


    private void Update()
    {

        if (!room.playerEnteredTheRoom)
        {
            exitBlock.SetActive(true);

        }
        else
        { 

        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if ((collision.tag == "Player") && (!transform.GetChild(0).gameObject.active))
        {

            exitBlock.SetActive(true);
            FindObjectOfType<LevelGenerator>().ContinueLevel();
            Destroy(this);
        }
    }
}
