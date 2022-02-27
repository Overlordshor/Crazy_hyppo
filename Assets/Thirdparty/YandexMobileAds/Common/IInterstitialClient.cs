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

namespace YandexMobileAds.Common
{
    public interface IInterstitialClient
    {
        // Event fired when interstitial has been received.
        event EventHandler<EventArgs> OnInterstitialLoaded;

        // Event fired when interstitial has failed to load.
        event EventHandler<AdFailureEventArgs> OnInterstitialFailedToLoad;

        // Event fired when returned to application.
        event EventHandler<EventArgs> OnReturnedToApplication;

        // Event fired when interstitial is leaving application.
        event EventHandler<EventArgs> OnLeftApplication;

        // Event fired when interstitial is shown.
        event EventHandler<EventArgs> OnInterstitialShown;

        // Event fired when interstitial is dismissed.
        event EventHandler<EventArgs> OnInterstitialDismissed;

        // Event fired when interstitial impression tracked.
        event EventHandler<ImpressionData> OnImpression;

        // Event fired when interstitial has failed to show.
        event EventHandler<AdFailureEventArgs> OnInterstitialFailedToShow;

        // Loads new interstitial ad.
        void LoadAd(AdRequest request);

        // Determines whether interstitial has loaded.
        bool IsLoaded();

        // Shows InterstitialAd.
        void Show();

        // Destroys InterstitialAd.
        void Destroy();
    }
}