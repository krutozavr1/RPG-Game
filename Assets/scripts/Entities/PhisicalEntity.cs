using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PhisicalEntity : MonoBehaviour
{
    public int maxHp, curHp;
    [SerializeField] bool hasHealthBar, canBeKnockbacked;
    protected SliderController healthBar;
    protected Rigidbody2D rb;
    public bool isInvinsible = false, isDead = false;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curHp = maxHp;
        if(hasHealthBar)
        {
            healthBar = GetComponentInChildren<SliderController>();
            healthBar.SetMaxValue(maxHp);
        }
    }


    public virtual void TakeDamage(int dmg)
    {
        if((!isInvinsible) && (curHp > 0))
        {
            curHp -= dmg;
            if(curHp > maxHp)
            {
                curHp = maxHp;
            }
            if(hasHealthBar)
            {
                healthBar.ChangeSliderVal(-dmg);
            }
            if(curHp <= 0)
            {
                Die();
            }
            else
            {

                StartCoroutine(BecomeInvinsible());
            }
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    private IEnumerator BecomeInvinsible()
    {
        isInvinsible = true;

        yield return new WaitForSeconds(.1f);

        isInvinsible = false;
    }

    public virtual void TakeKnockback(float force, Vector2 dir)
    {
        if ((!isInvinsible) && (canBeKnockbacked))
        {

            rb.AddForce(force * dir, ForceMode2D.Impulse);
        }
    }

    protected void SetMaxHp(int val)
    {
        maxHp = val;
        curHp = maxHp;
        healthBar.SetMaxValue(maxHp);
    }

}
