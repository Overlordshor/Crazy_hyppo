/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for iOS (C) 2019 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System.Runtime.InteropServices;

namespace YandexMobileAds.Platforms.iOS
{
    #if (UNITY_5 && UNITY_IOS) || UNITY_IPHONE

    internal class AdSizeBridge
    {
        [DllImport("__Internal")]
        internal static extern string YMAUnityCreateFixedAdSize(int width, int height);

        [DllImport("__Internal")]
        internal static extern string YMAUnityCreateStickyAdSize(int width);

        [DllImport("__Internal")]
        internal static extern string YMAUnityCreateFlexibleAdSize();

        [DllImport("__Internal")]
        internal static extern string YMAUnityCreateFlexibleAdSizeWithWidth(int width);

        [DllImport("__Internal")]
        internal static extern string YMAUnityCreateFlexibleAdSizeWithSize(int width, int height);
    }
    
    #endif
}