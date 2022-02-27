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
    public class RewardedAd
    {
        private AdRequestCreator adRequestFactory;
        private IRewardedAdClient client;
        private volatile bool loaded;

        public event EventHandler<EventArgs> OnRewardedAdLoaded;
        public event EventHandler<AdFailureEventArgs> OnRewardedAdFailedToLoad;
        public event EventHandler<EventArgs> OnReturnedToApplication;
        public event EventHandler<EventArgs> OnLeftApplication;
        public event EventHandler<EventArgs> OnRewardedAdShown;
        public event EventHandler<EventArgs> OnRewardedAdDismissed;
        public event EventHandler<ImpressionData> OnImpression;
        public event EventHandler<AdFailureEventArgs> OnRewardedAdFailedToShow;
        public event EventHandler<Reward> OnRewarded;

        public RewardedAd(string blockId)
        {
            this.adRequestFactory = new AdRequestCreator();
            this.client = YandexMobileAdsClientFactory.BuildRewardedAdClient(blockId);

            ConfigureRewardedAdEvents();
        }

        public void LoadAd(AdRequest request)
        {
            this.loaded = false;
            client.LoadAd(adRequestFactory.CreateAdRequest(request));
        }

        public bool IsLoaded()
        {
            return loaded;
        }

        public void Show()
        {
            client.Show();
        }

        public void Destroy()
        {
            client.Destroy();
        }

        private void ConfigureRewardedAdEvents()
        {
            this.client.OnRewardedAdLoaded += (sender, args) =>
            {
                this.loaded = true;
                if (this.OnRewardedAdLoaded != null)
                {
                    this.OnRewardedAdLoaded(this, args);
                }
            };

            this.client.OnRewardedAdFailedToLoad += (sender, args) =>
            {
                if (this.OnRewardedAdFailedToLoad != null)
                {
                    this.OnRewardedAdFailedToLoad(this, args);
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

            this.client.OnRewardedAdShown += (sender, args) =>
            {
                if (this.OnRewardedAdShown != null)
                {
                    this.OnRewardedAdShown(this, args);
                }
            };

            this.client.OnRewardedAdDismissed += (sender, args) =>
            {
                if (this.OnRewardedAdDismissed != null)
                {
                    this.OnRewardedAdDismissed(this, args);
                }
            };

            this.client.OnImpression += (sender, args) =>
            {
                if (this.OnImpression != null)
                {
                    this.OnImpression(this, args);
                }
            };

            this.client.OnRewardedAdFailedToShow += (sender, args) =>
            {
                if (this.OnRewardedAdFailedToShow != null)
                {
                    this.OnRewardedAdFailedToShow(this, args);
                }
            };

            this.client.OnRewarded += (sender, args) =>
            {
                if (this.OnRewarded != null)
                {
                    this.OnRewarded(this, args);
                }
            };
        }
    }
}