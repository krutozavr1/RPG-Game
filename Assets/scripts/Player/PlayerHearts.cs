using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHearts : MonoBehaviour
{
    public static PlayerHearts instance;
    List<HpHeart> hearts = new List<HpHeart>();
    [SerializeField]int maxHearts;
    [SerializeField] GameObject heartPrefab;
    public int indexOfCurHeart, hpQuatersCnt;

    void Start()
    {
        instance = this;
    }

    public void TakeDamage(int quaters)
    {
        if(indexOfCurHeart >= 0)
        {
            hearts[indexOfCurHeart].LowerHpValue(quaters);
        }
    }

    public void RestoreSomeHealth(int quaters)
    {
        hearts[indexOfCurHeart].RaiseHpValue(quaters);
    }

    public void DeleteLastHeart(int remainingDmg = 0)
    {
        indexOfCurHeart -= 1;
        if(indexOfCurHeart < 0)
        {
            LoseAllHealth();
            PlayerGameMechanics.instance.Die();
            return;
        }
        if (remainingDmg != 0)
        {
            TakeDamage(remainingDmg);
        }
        
    }

    public bool TryUpdateActiveHeart()
    {
        if(indexOfCurHeart + 1 <= hearts.Count - 1)
        {
            indexOfCurHeart++;
            return true;
        }
        return false;
    }//checks if there is at least one more unfilled heart left

    public void CreateNewHeart(int hp = 4)
    {
        GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity, transform);
        heart.GetComponent<HpHeart>().curHpValue = hp;
        hearts.Add(heart.GetComponent<HpHeart>());
    }

    void LoseAllHealth()
    {
        foreach (HpHeart heart in hearts)
        {
            heart.LoseAllHeart();
        }
    }

    public void RestoreFullHealth()
    {
        foreach(HpHeart heart in hearts)
        {
            heart.RestoreFullHeart();
        }
        indexOfCurHeart = hearts.Count - 1;
    }

    public void SetMaximumAmountOfHearts(int val, bool fillToMax = true)
    {

        maxHearts = val;
        DestroyAllHearts();
        for(int i = 0; i < maxHearts;i++)
        {
            int quaters = Mathf.Clamp(hpQuatersCnt, 0, 4);
            hpQuatersCnt -= quaters;
            if(quaters > 0)
            {
                indexOfCurHeart++;
            }
            CreateNewHeart(quaters);
        }
        if(fillToMax)
        {
            RestoreFullHealth();
        }
        
    }

    private void DestroyAllHearts()
    {
        foreach(HpHeart heart in hearts.ToList())
        {
            Destroy(heart.gameObject);
            hearts.Remove(heart);
        }
        indexOfCurHeart = -1;
    }
    /*public override void SaveObjectData()
    {
        hpQuatersCnt = 0;
        foreach(HpHeart heart in hearts)
        {
            hpQuatersCnt += heart.curHpValue;
        }
        base.SaveObjectData();
    }

    public override void LoadObjectData(string jsonedData)
    {
        JsonUtility.FromJsonOverwrite(jsonedData, this);
        SetMaximumAmountOfHearts(maxHearts, false);
    }*/
}
