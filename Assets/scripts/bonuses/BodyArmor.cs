using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyArmor : Bonus
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            UseBonus();
            Destroy(gameObject);

        }
    }


    public override void UseBonus()
    {

    }
}
