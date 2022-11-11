using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Portal : MonoBehaviour
{

    [SerializeField] Transform destinationPoint;
    PortalKey portalKey;
    bool playerCanTP = false;

    void Start()
    {
        portalKey = FindObjectsOfType<PortalKey>(true)[0];
    }

    void Update()
    {
        if(playerCanTP && (Keyboard.current.eKey.wasReleasedThisFrame))
        {
            TeleportPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && portalKey.PlayerFoundPortalKey)
        {
            Tutorial.instance.Activate();
            playerCanTP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Tutorial.instance.Deactivate();
            playerCanTP = false;
        }
    }

    private void TeleportPlayer()
    {
        PlayerMovement.instance.transform.position = destinationPoint.position;
    }
}
