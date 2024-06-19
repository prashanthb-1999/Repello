using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using System;

public class ScoreManager : MonoBehaviour
{
    public Text finalScore;
    public Text highScore;
    string bannerAdId = "ca-app-pub-3940256099942544/6300978111";
    public BannerView bannerAd;
    
    // Start is called before the first frame update
    void Start()
    {
        highScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        //AdmobAds.instance.requestInterstital();
        //AdmobAds.instance.reqBannerAd();
        MobileAds.Initialize(initStatus => { });
        this.reqBannerAd();
    }

    // Update is called once per frame
    void Update()
    {
        finalScore.text = "Final Score: " + GameManager.score.ToString();

        if(GameManager.score > PlayerPrefs.GetInt("HighScore", 0)) {
            PlayerPrefs.SetInt("HighScore", GameManager.score);
            highScore.text = "High Score: " + GameManager.score.ToString();
        }
        
    }

    public void back() {
        
        //AdmobAds.instance.ShowInterstitialAd();
        //this.hideBanner();
        SceneManager.LoadScene("Menu");
    }

    public void reqBannerAd()
    {
        this.bannerAd = new BannerView(bannerAdId, AdSize.Banner, AdPosition.Top);

        // Called when an ad request has successfully loaded.
        this.bannerAd.OnAdLoaded += this.HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.bannerAd.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;

        AdRequest request = new AdRequest.Builder().Build();

        this.bannerAd.LoadAd(request);

    }


    public void hideBanner()
    {
        this.bannerAd.Hide();
    }

    //Delegates that i dont know
    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Ad Loaded");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("couldnt load ad");
    }
}
