/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for Unity (C) 2018 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;
using YandexMobileAds.Base;
using YandexMobileAds.Common;
using YandexMobileAds.Platforms;

namespace YandexMobileAds
{
    /// <summary>
    /// Class for displaying interstitial ad.
    /// </summary>
    public class Interstitial
    {
        private AdRequestCreator adRequestFactory;
        private IInterstitialClient client;
        private volatile bool loaded;

        public event EventHandler<EventArgs> OnInterstitialLoaded;
        public event EventHandler<AdFailureEventArgs> OnInterstitialFailedToLoad;
        public event EventHandler<EventArgs> OnReturnedToApplication;
        public event EventHandler<EventArgs> OnLeftApplication;
        public event EventHandler<EventArgs> OnInterstitialShown;
        public event EventHandler<EventArgs> OnInterstitialDismissed;
        public event EventHandler<ImpressionData> OnImpression;
        public event EventHandler<AdFailureEventArgs> OnInterstitialFailedToShow;

        /// <summary>
        /// The class constructor. 
        /// <param name="blockId"> Unique ad placement ID created at partner interface. Example: R-M-DEMO-240x400-context.</param>
        /// </summary>
        public Interstitial(string blockId)
        {
            this.adRequestFactory = new AdRequestCreator();
            this.client = YandexMobileAdsClientFactory.BuildInterstitialClient(blockId);

            ConfigureInterstitialEvents();
        }

        // Starts loading ad.
        public void LoadAd(AdRequest request)
        {
            this.loaded = false;
            client.LoadAd(adRequestFactory.CreateAdRequest(request));
        }

        // Returns true if this interstitial ad has been successfully loaded
        // and is ready to be shown, otherwise false.
        public bool IsLoaded()
        {
            return loaded;
        }

        // Shows interstitial ad, only if it has been loaded.
        public void Show()
        {
            client.Show();
        }

        // Destroys Interstitial entirely and cleans up resources.
        public void Destroy()
        {
            client.Destroy();
        }

        private void ConfigureInterstitialEvents()
        {
            this.client.OnInterstitialLoaded += (sender, args) =>
            {
                this.loaded = true;
                if (this.OnInterstitialLoaded != null)
                {
                    this.OnInterstitialLoaded(this, args);
                }
            };

            this.client.OnInterstitialFailedToLoad += (sender, args) =>
            {
                if (this.OnInterstitialFailedToLoad != null)
                {
                    this.OnInterstitialFailedToLoad(this, args);
                }
            };

            this.client.OnReturnedToApplication += (sender, args) =>
            {
                if (this.OnReturnedToApplication != null)
                {
                    this.OnReturnedToApplication(this, args);
                }
            };

            this.client.OnLeftApplication += (sender, args) =>
            {
                if (this.OnLeftApplication != null)
                {
                    this.OnLeftApplication(this, args);
                }
            };

            this.client.OnInterstitialShown += (sender, args) =>
            {
                if (this.OnInterstitialShown != null)
                {
                    this.OnInterstitialShown(this, args);
                }
            };

            this.client.OnInterstitialDismissed += (sender, args) =>
            {
                if (this.OnInterstitialDismissed != null)
                {
                    this.OnInterstitialDismissed(this, args);
                }
            };

            this.client.OnImpression += (sender, args) =>
            {
                if (this.OnImpression != null)
                {
                    this.OnImpression(this, args);
                }
            };

            this.client.OnInterstitialFailedToShow += (sender, args) =>
            {
                if (this.OnInterstitialFailedToShow != null)
                {
                    this.OnInterstitialFailedToShow(this, args);
                }
            };

        }
    }
}