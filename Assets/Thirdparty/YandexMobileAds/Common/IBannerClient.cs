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
    public interface IBannerClient
    {
        // Event fired when banner has been received.
        event EventHandler<EventArgs> OnAdLoaded;

        // Event fired when banner has failed to load.
        event EventHandler<AdFailureEventArgs> OnAdFailedToLoad;

        // Event fired when returned to application.
        event EventHandler<EventArgs> OnReturnedToApplication;

        // Event fired when banner is leaving application.
        event EventHandler<EventArgs> OnLeftApplication;

        // Event fired when impression was tracked.
        event EventHandler<ImpressionData> OnImpression;

        // Requests new ad for banner view.
        void LoadAd(AdRequest request);

        // Shows banner view on screen.
        void Show();

        // Hides banner view from screen.
        void Hide();

        // Destroys banner view.
        void Destroy();
    }
}