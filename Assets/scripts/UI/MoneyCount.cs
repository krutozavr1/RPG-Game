using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyCount : MonoBehaviour
{
    public static MoneyCount instance;
    TextMeshProUGUI tmp;
    public int curScore = 100;

    void Awake()
    {
        tmp = GetComponent<TextMeshProUGUI>();
        instance = this;
        ChangeMoneyScore(0);
    }


    public void ChangeMoneyScore(int val)
    {

        curScore += val;
        tmp.text = curScore.ToString();
    }

    public void SetCurScore(int val)
    {
        curScore = val;
        tmp.text = curScore.ToString();
    }
}
