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
    public static class ScreenUtils
    {
        public static int ConvertPixelsToDp(int pixels)
        {
            IScreenClient client = YandexMobileAdsClientFactory.CreateScreenClient();
            return (int)(pixels / client.GetScreenScale());
        }
    }
}
