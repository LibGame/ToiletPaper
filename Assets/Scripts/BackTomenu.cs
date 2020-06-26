using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTomenu : MonoBehaviour
{
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Money"))
        {
            PlayerPrefs.SetInt("Money", 100);
        }
    }

    public void BackToMenue()
    {

        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }
    public void LoadShop()
    {
        Invoke("InvokeShop", 0.3f);
    }
    public void StartPlay()
    {
        FadeOut.sceneEnd = true;

    }

    private void InvokeShop()
    {
        SceneManager.LoadScene("Shop");

    }
}
