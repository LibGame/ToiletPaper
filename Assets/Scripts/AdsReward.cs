using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class AdsReward : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "3539559"; // идентификатор приложения
    public Button myButton; // кнопка, которая будет показывать ролик
    public string myPlacementId = "rewardedVideo"; // идентификатор видео, по умолчанию 'rewardedVideo'
    private LoseTable tableLose;
    private bool isClick;
    private Interface inter;
    private PaperMovesDown paperMove;

    void Start()
    {
        inter = GameObject.Find("Interface").GetComponent<Interface>();
        paperMove = FindObjectOfType<PaperMovesDown>();

        if (Interface.amountAdvertising % 2 == 0)
        {
            myButton.interactable = Advertisement.IsReady(myPlacementId);
            if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, true);
        }
        else
        {
            gameObject.SetActive(false);
        }

    }

    void ShowRewardedVideo()
    {
        isClick = true;
        Interface.PlayerHelth = 3;
        Advertisement.Show(myPlacementId);
        tableLose = GameObject.Find("LoseTable(Clone)").GetComponent<LoseTable>();
        tableLose.DestroyObj();
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
        Debug.Log("ошибка");
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
                paperMove._isStopedGame = false;

            }
            else if (showResult == ShowResult.Skipped)
            {
            }
            else if (showResult == ShowResult.Failed)
            {

            }
        }

    }
    
}
