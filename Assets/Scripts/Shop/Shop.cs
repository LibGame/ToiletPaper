using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Shop : MonoBehaviour
{

    public Text _moneys;
    public static int playerWallet;
    public int Money;

    void Start()
    {

        if (PlayerPrefs.HasKey("Money"))
        {
            Money = PlayerPrefs.GetInt("Money");
            _moneys.text = Money.ToString();

        }
    }

    public void ShowMoney()
    {
        _moneys.text = Money.ToString();

    }

}
