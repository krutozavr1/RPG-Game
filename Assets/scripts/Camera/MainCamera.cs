using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public static MainCamera instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        
    }

    void LateUpdate()
    {
        if(GameManager.instance.player != null)
        { 
            transform.position = GameManager.instance.player.transform.position;
        }
    }
}
