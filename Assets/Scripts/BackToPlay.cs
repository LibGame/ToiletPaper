using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class BackToPlay : MonoBehaviour
{

    public Button crossButton;
    private Interface inter;

    private void Start()
    {
        crossButton.onClick.AddListener(BackToPlays);
        inter = FindObjectOfType<Interface>();
    }

    public void BackToPlays()
    {
        inter.StartAllBlots();
        inter.StartAllPaper();
        Destroy(GameObject.Find("SettingsTable(Clone)"));
    }
}
