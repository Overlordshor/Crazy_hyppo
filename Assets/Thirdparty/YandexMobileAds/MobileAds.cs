/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for iOS (C) 2019 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;
using YandexMobileAds.Common;
using YandexMobileAds.Platforms;

namespace YandexMobileAds
{
    public static class MobileAds
    {
        public static void SetUserConsent(bool consent)
        {
            IMobileAdsClient mobileAds = YandexMobileAdsClientFactory.CreateMobileAdsClient();
            mobileAds.SetUserConsent(consent);
        }
    }
}
