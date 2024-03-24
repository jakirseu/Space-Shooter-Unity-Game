using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdManager : MonoBehaviour
{
   static private BannerView bannerView;
   static private InterstitialAd interstitial;
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestBanner();
        RequestInterstitial();


    }


    private void RequestBanner()
    {

        #if UNITY_ANDROID
                string adUnitId = "";
        #elif UNITY_IPHONE
                            string adUnitId = "";
        #else
                            string adUnitId = "unexpected_platform";
        #endif

        bannerView = new BannerView(adUnitId, AdSize.SmartBanner, AdPosition.Bottom);

        AdRequest request = new AdRequest.Builder().Build();


        bannerView.LoadAd(request);


    }


    private void RequestInterstitial()
    {
        #if UNITY_ANDROID
                string adUnitId = "";
        #elif UNITY_IPHONE
                string adUnitId = "";
        #else
                string adUnitId = "unexpected_platform";
        #endif

        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }


    static public void ShowIntersitial()
    {
        if (interstitial.IsLoaded())
        {
            interstitial.Show();
        }
    }



    static public void ShowBanner()
    {
        bannerView.Show();
    }

    static public void HideBanner()
    {
        bannerView.Hide();
    }
}
