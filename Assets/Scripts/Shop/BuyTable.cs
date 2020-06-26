using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BuyTable : MonoBehaviour
{
    [SerializeField]
    private Text _price;
    [SerializeField]
    private Image _iconAbility;
    [SerializeField]
    private Text _description;
    public Canvas canvas;
    public string NameOfItem;
    public int Amount;
    public int Price;

    private void Start()
    {
        canvas.worldCamera = Camera.main;
        canvas.sortingOrder = 3;
    }

    public void SetSettings(string price , string discription , Sprite icon , int itemChose)
    {
        _price.text = price;
        _description.text = discription;
        _iconAbility.sprite = icon;
        Price = Convert.ToInt32(price);

        if (itemChose == 1)
        {
            NameOfItem = "luckyX2";
            Amount = 1;
        }
        else if (itemChose == 2)
        {
            NameOfItem = "luckyX3";
            Amount = 2;
        }
        else if (itemChose == 3)
        {
            NameOfItem = "luckyX6";
            Amount = 3;
        }
        else if (itemChose == 4)
        {
            NameOfItem = "doublLifeX2";
            Amount = 1;
        }
        else if (itemChose == 5)
        {
            NameOfItem = "doublLifeX3";
            Amount = 1;
        }
        else if (itemChose == 6)
        {
            NameOfItem = "doublLifeX6";
            Amount = 1;
        }
        else if (itemChose == 7)
        {
            NameOfItem = "FreeLife";
            Amount = 1;
        }
        else if (itemChose == 8)
        {
            NameOfItem = "ChanceDodge";
            Amount = 1;
        }
        else if (itemChose == 9)
        {
            NameOfItem = "MoreScoreChance";
            Amount = 1;
        }
        else if (itemChose == 10)
        {
            NameOfItem = "backGround";
            Amount = 1;
        }
        else if (itemChose == 11)
        {
            NameOfItem = "backGround";
            Amount = 2;
        }
        else if (itemChose == 12)
        {
            NameOfItem = "backGround";
            Amount = 3;
        }
        else if (itemChose == 13)
        {
            NameOfItem = "backGround";
            Amount = 4;
        }
        else if (itemChose == 14)
        {
            NameOfItem = "backGround";
            Amount = 5;
        }
        else if (itemChose == 15)
        {
            NameOfItem = "backGround";
            Amount = 6;
        }
        else if (itemChose == 16)
        {
            NameOfItem = "backGround";
            Amount = 7;
        }
        else if (itemChose == 17)
        {
            NameOfItem = "backGround";
            Amount = 8;
        }
        else if (itemChose == 18)
        {
            NameOfItem = "backGround";
            Amount = 9;
        }
        else if (itemChose == 19)
        {
            NameOfItem = "backGround";
            Amount = 10;
        }
        else if (itemChose == 20)
        {
            NameOfItem = "backGround";
            Amount = 11;
        }
        else if (itemChose == 21)
        {
            NameOfItem = "backGround";
            Amount = 12;
        }
        else if (itemChose == 22)
        {
            NameOfItem = "paper";
            Amount = 1;
        }
        else if (itemChose == 23)
        {
            NameOfItem = "paper";
            Amount = 2;
        }
        else if (itemChose == 24)
        {
            NameOfItem = "paper";
            Amount = 3;
        }
        else if (itemChose == 25)
        {
            NameOfItem = "paper";
            Amount = 4;
        }
        else if (itemChose == 26)
        {
            NameOfItem = "paper";
            Amount = 5;
        }
        else if (itemChose == 27)
        {
            NameOfItem = "paper";
            Amount = 6;
        }
        else if (itemChose == 28)
        {
            NameOfItem = "paper";
            Amount = 7;
        }
        else if (itemChose == 29)
        {
            NameOfItem = "paper";
            Amount = 8;
        }
    }
}
