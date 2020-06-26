using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Banner : MonoBehaviour
{
    public string gameId = "1234567";
    public string placementId = "bannerPlacement";
    public bool testMode = true;

    void Start()
    {
        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(1f);
        }
        Advertisement.Banner.Show(placementId);
    }
}
