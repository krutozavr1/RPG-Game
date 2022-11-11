using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Animator anim;
    protected Rigidbody2D rb;
    public bool isKnockbacked = false;
    public int dmg, speed, hp;

    protected virtual void Start()
    {
        GetComponents();
    }

    protected void GetComponents()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }



    public void SetStat(string type, int val)
    {
        switch (type)
        {
            case "hp": FindObjectOfType<PlayerHearts>().SetMaximumAmountOfHearts(val); hp = val; break;
            case "dmg": FindObjectOfType<PlayerWeapon>().ApplyAdditionalDmg(val); dmg = val; break;
            case "speed": GetComponent<PlayerMovement>().speedBonus = 1 + val / 10f; speed = val; break;


        }
    }
}
