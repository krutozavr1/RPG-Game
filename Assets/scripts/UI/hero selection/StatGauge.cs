using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatGauge : MonoBehaviour
{
    static int points = 5;
    int max = 7, startCellCnt;
    [SerializeField] GridLayoutGroup container;
    [SerializeField] TextMeshProUGUI pointsCnt;
    [SerializeField] GameObject cellPrefab;
    [SerializeField] Color32 cellColor;
    public static bool canDecreaseStat = false, canIncreaseStat = false;

    enum Type {hp, dmg, speed}
    [SerializeField]Type type;

    void OnEnable()
    {
        SetStartCellCnt();
    }

    void DestroyOldCells()
    {
        int childs = container.transform.childCount;
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(container.transform.GetChild(i).gameObject);
        }
    }

    void SetStartCellCnt()
    {
        DestroyOldCells();
        if (type == Type.dmg)
        {
            startCellCnt = FindObjectOfType<Player>().dmg;
        }
        else if(type == Type.hp)
        {
            startCellCnt = FindObjectOfType<Player>().hp;
        }
        else
        {
            startCellCnt = FindObjectOfType<Player>().speed;
        }
        CreateNewCells();
    }

    void CreateNewCells()
    {
        for (int i = 0; i < startCellCnt; i++)
        {
            GameObject curCell = Instantiate(cellPrefab, transform.position, Quaternion.identity, container.transform);
            curCell.GetComponent<Image>().color = cellColor;
        }
    }

    public void IncreaseStat()
    {
        if((container.transform.childCount < max) && (((points > 0) && (pointsCnt != null)) || (canIncreaseStat)))
        {
            GameObject newCell = Instantiate(cellPrefab, cellPrefab.transform.position, Quaternion.identity, container.transform);
            newCell.GetComponent<Image>().color = cellColor;

            if (pointsCnt != null)
            {
                points--;
                pointsCnt.text = "Points left: " + points.ToString();
            }
        }
        else
        {
            FindObjectOfType<LevelUpMenu>().SellOneLevel(true);
        }
        canIncreaseStat = false;
    }

    public void DecreaseStat()
    {
        canDecreaseStat = false;
        if(container.transform.childCount > startCellCnt)
        {
            canDecreaseStat = true;
            Destroy(container.transform.GetChild(container.transform.childCount - 1).gameObject);
            if(pointsCnt != null)
            {
                points++;
                pointsCnt.text = "Points left: " + points.ToString();
            }
        }
    }

    public void SubmitStartData()
    {
        switch (type)
        {
            case Type.hp: GetComponentInParent<HeroCreationScreen>().hpStat = container.transform.childCount; break;
            case Type.dmg: GetComponentInParent<HeroCreationScreen>().dmgStat = container.transform.childCount; break;
            case Type.speed: GetComponentInParent<HeroCreationScreen>().speedStat = container.transform.childCount; break;
        }
    }

    public void ApllyLevelUpgrades()
    {
        switch (type)
        {
            case Type.dmg: FindObjectOfType<Player>().SetStat("dmg", container.transform.childCount);break;
            case Type.hp: FindObjectOfType<Player>().SetStat("hp", container.transform.childCount);break;
            case Type.speed: FindObjectOfType<Player>().SetStat("speed", container.transform.childCount);break;
        }
    }
}
