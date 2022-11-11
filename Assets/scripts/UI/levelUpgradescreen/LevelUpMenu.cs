using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpMenu : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI soulsNeeded, soulsRemain;
    float curCnt, curNeed = 10;


    private void OnEnable()
    {
        curCnt = MoneyCount.instance.curScore;
        UpdateNeededCnt();
        UpdateRemainingCnt();
    }


    void UpdateNeededCnt()
    {
        soulsNeeded.text = "Souls need per level:" + (Mathf.Round(curNeed)).ToString();
    }

    void UpdateRemainingCnt()
    {
        soulsRemain.text = "Remaining souls:" + (Mathf.Round(curCnt)).ToString();

    }

    public void BuyOneLevel()
    {
        if(curCnt >= curNeed)
        {
            StatGauge.canIncreaseStat = true;
            curCnt -= curNeed;
            curNeed *= 1.2f;
            UpdateNeededCnt();
            UpdateRemainingCnt();
        }
    }

    public void SellOneLevel(bool forceSell = false)
    {
        if((StatGauge.canDecreaseStat) || (forceSell))
        {
            curNeed /= 1.2f;
            curCnt += curNeed;
            UpdateNeededCnt();
            UpdateRemainingCnt();
        }
        
    }

    public void ApplyAllChanges()
    {
        foreach(StatGauge gauge in FindObjectsOfType<StatGauge>())
        {
            gauge.ApllyLevelUpgrades();
        }
        MoneyCount.instance.SetCurScore((int)curCnt);
    }
}
