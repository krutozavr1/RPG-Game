using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpHeart : MonoBehaviour
{
    [SerializeField] List<Sprite> heartSprites;
    public int curHpValue = 4;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();   
    }

    void Update()
    {
        image.sprite = heartSprites[curHpValue];
    }

    public void LowerHpValue(int value)
    {
        if (curHpValue <= value)
        {
            PlayerHearts.instance.DeleteLastHeart(value - curHpValue);
            curHpValue = 0;
        }
        else
        {
            curHpValue -= value;
        }
    }

    public void RaiseHpValue(int value)
    {
        while((curHpValue < 4) && (value > 0))
        {
            curHpValue++;
            value--;
        }
        if(value > 0)
        {
            if (PlayerHearts.instance.TryUpdateActiveHeart())
            {
                PlayerHearts.instance.RestoreSomeHealth(value);
            }
        }
    }


    public void RestoreFullHeart()
    {
        curHpValue = 4;
    }

    public void LoseAllHeart()
    {
        curHpValue = 0;
    }

}
