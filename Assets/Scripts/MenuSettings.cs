using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSettings : MonoBehaviour
{
    public GameObject SettingsMenuPref;
    private Interface inter;
    public static float SaveSpeed;
    void Start()
    {
        inter = GameObject.Find("Interface").GetComponent<Interface>();
    }



    public void OpenSettingMenu()
    {
        inter.StopAllBlots();
        inter.StopAllPaper();
        Instantiate(SettingsMenuPref, new Vector2(0, 0), Quaternion.identity);
    }
}
