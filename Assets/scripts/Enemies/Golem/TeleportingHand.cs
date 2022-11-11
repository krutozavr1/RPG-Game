using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class TeleportingHand : MonoBehaviour
{
    PathCreator circleAroundPlayer;
    
    public PathCreator Circle
    {
        set
        {
            circleAroundPlayer = value;
        }
    }

    public void PositionAroundPlayer()
    {
        transform.position = circleAroundPlayer.path.GetPointAtDistance(Random.Range(0, 10));
        transform.up = -(PlayerGameMechanics.instance.transform.position - transform.position).normalized;
    }

    private void DestroySelf()
    {

        Destroy(gameObject);
    }
}
