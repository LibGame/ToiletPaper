using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoubleCoinButton : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "3539559"; // идентификатор приложения
    public Button myButton; // кнопка, которая будет показывать ролик
    public string myPlacementId = "rewardedVideoDoubleMoney"; // идентификатор видео, по умолчанию 'rewardedVideo'
    private Interface insterface;
    public LoseTable tableLose;
    private bool isWas;
    private PlayerWallet playerWallet;
    private bool isClick;
    public bool _isWinTable;

    void Start()
    {
        myButton.interactable = Advertisement.IsReady(myPlacementId);
        playerWallet = GameObject.Find("PlayerWallet").GetComponent<PlayerWallet>();

        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    void ShowRewardedVideo()
    {
        isClick = true;
        insterface = GameObject.Find("Interface").GetComponent<Interface>();

        if (_isWinTable)
        {
            Destroy(GameObject.Find("WinTable(Clone)"));
        }
        else
        {
            Destroy(GameObject.Find("LoseTable(Clone)"));
        }
      
        Interface.PlayerHelth = 2;
        Advertisement.Show(myPlacementId);

    }

    void IUnityAdsListener.OnUnityAdsReady(string placementId)
    {
        if (placementId == myPlacementId && myButton != null)
        {
            myButton.interactable = true;
        }
    }

    void IUnityAdsListener.OnUnityAdsDidError(string message)
    {
        Debug.Log("Error");
    }

    void IUnityAdsListener.OnUnityAdsDidStart(string placementId)
    {
    }

    void IUnityAdsListener.OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (isClick)
        {
            if (showResult == ShowResult.Finished)
            {
                playerWallet.WalletAndRecord(1);
                SceneManager.LoadScene("Menu");

            }
            else if (showResult == ShowResult.Skipped)
            {
                SceneManager.LoadScene("Menu");
            }
            else if (showResult == ShowResult.Failed)
            {
                SceneManager.LoadScene("Menu");
                Debug.Log("Error");
            }

        }
    }
}
