using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{

    [SerializeField] float idleRadius, chasingRadius, angle;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] GameObject eyeIcon;
    public float radius;
    GameObject player;
    public bool seesPlayer { get; private set; }


    void Start()
    {
        StartCoroutine(CheckFOV());
        radius = idleRadius;

    }

    private IEnumerator CheckFOV()
    {
        WaitForSeconds wait = new WaitForSeconds(.2f);
        while(true)
        {
            yield return wait;
            CheckAngularCast();

        }
    }

    private void CheckAngularCast()
    {
        Collider2D[] circleCheck = Physics2D.OverlapCircleAll(transform.position, radius, playerLayer);
        if(circleCheck.Length > 0)
        {
            Transform target = circleCheck[0].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if(Vector2.Angle(transform.right, dirToTarget) < angle / 2)
            {
                if(Physics2D.Raycast(transform.position, dirToTarget, radius, playerLayer) && (!seesPlayer))
                {
                    LocatePlayer();
                }
            }
        }
        else if(seesPlayer)
        {
            LosePlayer();
        }
        
    }

    public void LocatePlayer()
    {
        seesPlayer = true;
        radius = chasingRadius;
        eyeIcon.SetActive(true);
    }

    private void LosePlayer()
    {
        seesPlayer = false;
        radius = idleRadius;
        eyeIcon.SetActive(false);

    }

}
