using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    MoneyCount cnt;
    void Start()
    {
        cnt = FindObjectOfType<MoneyCount>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ChangeMoneyScoreAndDestroy();
        }
    }

    void ChangeMoneyScoreAndDestroy()
    {
        cnt.ChangeMoneyScore(1);
        Destroy(gameObject);
    }
}
