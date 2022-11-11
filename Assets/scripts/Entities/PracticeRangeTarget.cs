using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;
public class PracticeRangeTarget : MonoBehaviour
{
    PathCreator path;
    float dist = 0;
    [SerializeField] float speed;

    void Start()
    {
        path = transform.parent.GetComponent<PathCreator>();
    }

    void Update()
    {
        dist += speed * Time.deltaTime;
        transform.position = path.path.GetPointAtDistance(dist);
        if(PlayerMovement.instance.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "axeHitTrigger")
        {
            FindObjectOfType<ShootingRange>().RemoveCurTarget();
        }
    }

}
