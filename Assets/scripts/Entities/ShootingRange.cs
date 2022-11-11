using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{

    [SerializeField]List<GameObject> targets = new List<GameObject>();
    [SerializeField]Trigger path;


    public void RemoveCurTarget()
    {
        Destroy(targets[0]);
        targets.RemoveAt(0);
        ShowNextTarget();
    }

    public void ShowNextTarget()
    {
        if(targets.Count > 0)
        {
            targets[0].SetActive(true);
        }
        else
        {
            OpenPath();
        }
    }

    private void HideCurTarget()
    {
        if (targets.Count > 0)
        {
            targets[0].SetActive(false);
        }
    }

    private void OpenPath()
    {
        path.ActivateEvent();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ShowNextTarget();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HideCurTarget();
        }
    }
}
