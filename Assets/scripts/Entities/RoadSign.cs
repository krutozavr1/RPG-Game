using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoadSign : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI tmp;

    void Start()
    {
        //tmp = GetComponentInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            tmp.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            tmp.gameObject.SetActive(false);
        }
    }
}
