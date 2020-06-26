using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Previous : MonoBehaviour
{
    public Image img;
    public Sprite sprite;

    public void ChangeSprite()
    {
        img.sprite = sprite;
    }

}
