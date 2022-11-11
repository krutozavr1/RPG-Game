using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    bool isTriggered = false;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<PhisicalEntity>())
        {
            if(!isTriggered)
            {
                StartCoroutine(TriggerSpikes());
            }
        }
    }

    private IEnumerator TriggerSpikes()
    {
        isTriggered = true;
        yield return new WaitForSeconds(.45f);
        anim.SetTrigger("Trigger");
    }

    private void HideSpikes() //called from anim
    {
        isTriggered = false;
    }
}
