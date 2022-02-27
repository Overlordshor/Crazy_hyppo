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
    /// Class for displaying banner ad view.
    /// </summary>
    public class Banner
    {
        private AdRequestCreator adRequestFactory;
        private IBannerClient client;

        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<AdFailureEventArgs> OnAdFailedToLoad;
        public event EventHandler<EventArgs> OnReturnedToApplication;
        public event EventHandler<EventArgs> OnLeftApplication;
        public event EventHandler<ImpressionData> OnImpression;

        /// <summary>
        /// The class constructor. 
        /// <param name="blockId"> Unique ad placement ID created at partner interface. Example: R-M-DEMO-320x50.</param>
        /// <param name="adSize"> The size of banner ad. <see cref="YandexMobileAds.Base.AdSize"/></param>
        /// <param name="position"> Banner position on screen <see cref="YandexMobileAds.Base.AdPosition"/></param>
        /// </summary>
        public Banner(string blockId, AdSize adSize, AdPosition position)
        {
            this.adRequestFactory = new AdRequestCreator();
            this.client = YandexMobileAdsClientFactory.BuildBannerClient(blockId, adSize, position);

            ConfigureBannerEvents();
        }

        // Starts loading Banner Ad.
        public void LoadAd(AdRequest request)
        {
            client.LoadAd(adRequestFactory.CreateAdRequest(request));
        }

        // Hides BannerView from screen.
        public void Hide()
        {
            client.Hide();
        }

        // Shows BannerView on screen.
        public void Show()
        {
            client.Show();
        }

        // Destroys BannerView.
        public void Destroy()
        {
            client.Destroy();
        }

        private void ConfigureBannerEvents()
        {
            this.client.OnAdLoaded += (sender, args) =>
            {
                if (this.OnAdLoaded != null)
                {
                    this.OnAdLoaded(this, args);
                }
            };

            this.client.OnAdFailedToLoad += (sender, args) =>
            {
                if (this.OnAdFailedToLoad != null)
                {
                    this.OnAdFailedToLoad(this, args);
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

            this.client.OnImpression += (sender, args) =>
            {
                if (this.OnImpression != null)
                {
                    this.OnImpression(this, args);
                }
            };
        }
    }
}