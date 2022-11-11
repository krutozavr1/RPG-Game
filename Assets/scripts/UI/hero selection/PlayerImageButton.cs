using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerImageButton : MonoBehaviour
{
    [SerializeField] Sprite image;
    [SerializeField] string color;

    private void Start()
    {
        SetImage();
    }
    public void SetImage()
    {
        GetComponentInParent<HeroCreationScreen>().SetImage(image, "player");
        GetComponentInParent<HeroCreationScreen>().playerSkin = color;

    }


}
