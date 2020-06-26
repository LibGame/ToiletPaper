using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitFromBuyTable : MonoBehaviour
{

    private GameObject _buyTable;

    private void Start()
    {
        _buyTable = GameObject.Find("BuyTable(Clone)");
    }

    public void BackToShop()
    {
        Destroy(_buyTable);
        Destroy(gameObject);

    }

}
