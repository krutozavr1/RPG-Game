using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchingEntity : MonoBehaviour
{
    [SerializeField] float turnCd;
    LineOfSight lineOfSight;
    public bool onWatch = true;
    float timePassed;
    void Start()
    {
        lineOfSight = GetComponentInChildren<LineOfSight>();
    }

    void Update()
    {
        onWatch = !lineOfSight.seesPlayer;
        if((timePassed > turnCd) && (onWatch))
        {
            TurnAround();
        }
        timePassed += Time.deltaTime;
    }

    private void TurnAround()
    {
        GetComponent<Enemy>().Flip();
        timePassed = 0;
    }
}
