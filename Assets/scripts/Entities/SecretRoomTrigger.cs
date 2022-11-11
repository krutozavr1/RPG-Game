using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class SecretRoomTrigger : MonoBehaviour
{
    TilemapRenderer render;
    [SerializeField] GameObject roomContent;
    void Start()
    {
        render = GetComponent<TilemapRenderer>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            render.enabled = true;
            roomContent.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            render.enabled = false;
            roomContent.SetActive(false);
        }
    }
}
