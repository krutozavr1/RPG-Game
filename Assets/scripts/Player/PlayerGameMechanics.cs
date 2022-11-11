using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerGameMechanics : Player
{
    public static PlayerGameMechanics instance;
    bool isInvinsible = false, isDead = false;
    Inventory inventory;
    [SerializeField] GameObject deathSoulsPrefab;

    private void Awake()
    {
        instance = this;
        inventory = FindObjectsOfType<Inventory>(true)[0];

    }

    public void TakeDamage(int dmg)
    {
        if(!isInvinsible)
        {

            dmg /= 10;
            PlayerHearts.instance.TakeDamage(dmg);
            StartCoroutine(BecomeInvinsible());
        }
    }

    public void Die()
    {
        if(!isDead)
        {
            isDead = true;
            CreateDeathSouls();
            GetComponent<PlayerInput>().DeactivateInput();
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            FindObjectOfType<DeathScreen>().ShowDeathScreen();
        }
    }

    private void CreateDeathSouls()
    {
        foreach(PocketSouls soul in FindObjectsOfType<PocketSouls>())
        {
            Destroy(soul.gameObject);
        }
        GameObject souls = Instantiate(deathSoulsPrefab, transform.position, deathSoulsPrefab.transform.rotation);
        souls.GetComponent<PocketSouls>().value = MoneyCount.instance.curScore;
        MoneyCount.instance.SetCurScore(0);
    }

    public void Respawn()
    {

        isDead = false;
        PlayerHearts.instance.RestoreFullHealth();
        GetComponent<PlayerInput>().ActivateInput();
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;


    }

    private IEnumerator BecomeInvinsible()
    {
        isInvinsible = true;

        yield return new WaitForSeconds(.1f);

        isInvinsible = false;
    }

    public void OnOpenInventory()
    {
        inventory.gameObject.SetActive(!inventory.gameObject.active);
        Time.timeScale = (Time.timeScale + 1) % 2;
    }
}
