using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwinBlade : MonoBehaviour
{

    int dmg, knockbackVal;
    private void Start()
    {
        //dmg = transform.parent.parent.GetComponent<Weapon>().dmg;
        //knockbackVal = transform.parent.parent.GetComponent<Weapon>().knockbackVal;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "enemy")
        {

            Vector3 direction = (collision.transform.position - transform.position).normalized;
           // collision.GetComponent<Enemy>().GetDamage(dmg);
            //collision.GetComponent<Enemy>().GetKnockback(knockbackVal, direction);
        }
    }
}
