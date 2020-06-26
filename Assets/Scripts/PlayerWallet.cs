using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    public int PlayerMoney = 0;
    private Interface inter;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Money"))
        {
            PlayerMoney = PlayerPrefs.GetInt("Money");
        }

    }

    public void WalletAndRecord(int factor)
    {
        inter = GameObject.Find("Interface").GetComponent<Interface>();
        PlayerMoney += (inter.score / 2) * factor;
        PlayerPrefs.SetInt("Money", PlayerMoney);
        PlayerPrefs.Save();
    }
}
