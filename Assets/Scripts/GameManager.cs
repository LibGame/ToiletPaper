using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Image BackGround;
    public SpriteRenderer paperRoll;
    public SpriteRenderer[] papers;
    public Sprite[] papersSkin;
    public Sprite[] papersRollsSkin;
    public Sprite[] backGroundSkin;

    public void Start()
    {
        if (PlayerPrefs.HasKey("backGround"))
        {
            BackGround.sprite = backGroundSkin[PlayerPrefs.GetInt("backGround")];
        }
        if (PlayerPrefs.HasKey("paper"))
        {
            paperRoll.sprite = papersRollsSkin[PlayerPrefs.GetInt("paper")];
        }
        if (PlayerPrefs.HasKey("paper"))
        {
            for(int i = 0; i > papers.Length; i++)
            {
                papers[i].sprite = papersSkin[PlayerPrefs.GetInt("paper")];

            }
        }
    }

}
