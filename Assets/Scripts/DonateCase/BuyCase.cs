using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCase : MonoBehaviour
{
    private Shop shop;
    private BuyTable buyTable;
    public AudioSource buySound;
    public AudioSource EnughMoneySound;
    public GameObject BoughtPref;

    private void Start()
    {
        shop = FindObjectOfType<Shop>();
        buyTable = FindObjectOfType<BuyTable>();
    }
    private void SaveMone()
    {
        PlayerPrefs.SetInt("Money", shop.Money);
        PlayerPrefs.Save();
        shop.ShowMoney();
    }



    public void BuyItem()
    {
        if (shop.Money > buyTable.Price)
        {
            shop.Money -= buyTable.Price;
            if (!PlayerPrefs.HasKey(buyTable.NameOfItem))
            {
                PlayerPrefs.SetInt(buyTable.NameOfItem, buyTable.Amount);
            }
            else
            {
                var pref = Instantiate(BoughtPref);
                pref.transform.SetParent(gameObject.transform);
            }
            SaveMone();
        }

    }

}
