using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeroCreationScreen : MonoBehaviour
{
    [SerializeField] Image heroImage, weaponImage, giftImage;
    public int hpStat, dmgStat, speedStat;
    public GameObject weapon, gift;
    public string playerSkin;
    Player player;

    void Start()
    {
        Time.timeScale = 0;
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        
    }

    public void SetImage(Sprite image, string type)
    {
        switch (type)
        {
            case "player": heroImage.sprite = image; FindObjectsOfType<InventoryInfoWindow>(true)[0].SetPlayerImage(heroImage.sprite); break;
            case "weapon": weaponImage.sprite = image; break;
            case "gift": giftImage.sprite = image; break;
        }

    }

    public void CollectAllData()// collects start stats, weapon etc
    {
        foreach(StatGauge gauge in FindObjectsOfType<StatGauge>())
        {
            gauge.SubmitStartData();
        }
        FindObjectOfType<WeaponSelector>().SubmitData();
        FindObjectOfType<GiftSelector>().SubmitData();
        ApplyAllThings();
    }

    void ApplyAllThings()
    {
        if(playerSkin == "white")
        {
            player.GetComponent<Animator>().SetLayerWeight(player.GetComponent<Animator>().GetLayerIndex("white"), 1);
        }
        else
        {
            player.GetComponent<Animator>().SetLayerWeight(player.GetComponent<Animator>().GetLayerIndex("black"), 1);
        }
        FindObjectOfType<StartGearAndStatTuner>().SetGear(weapon, gift);
        FindObjectOfType<StartGearAndStatTuner>().SetStats(hpStat, speedStat, dmgStat);
        Time.timeScale = 1;
        Destroy(gameObject);
    }

}
