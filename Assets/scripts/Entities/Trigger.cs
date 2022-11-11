using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public virtual void ActivateEvent()
    {
        gameObject.SetActive(!gameObject.activeInHierarchy);
    }
}
