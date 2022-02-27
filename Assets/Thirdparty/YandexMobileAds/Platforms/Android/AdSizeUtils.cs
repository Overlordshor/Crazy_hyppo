using UnityEngine;
using YandexMobileAds.Base;

namespace YandexMobileAds.Platforms.Android
{
    internal class AdSizeUtils
    {
        public const string AdSizeClassName = "com.yandex.mobile.ads.banner.AdSize";
        public const string FlexibleSizeMethodName = "flexibleSize";
        public const string StickySizeMethodName = "stickySize";

        public static AndroidJavaObject GetAdSizeJavaObject(AdSize adSize)
        {
            AndroidJavaClass adSizeClass = new AndroidJavaClass(AdSizeClassName);
            AndroidJavaObject adSizeJavaObject = null;
            if (adSize.AdSizeType == AdSizeType.Sticky)
            {
                adSizeJavaObject = adSizeClass.CallStatic<AndroidJavaObject>(StickySizeMethodName, adSize.Width);
            }
            else if (adSize.AdSizeType == AdSizeType.Flexible)
            {
                adSizeJavaObject = GetFlexibleAdSize(adSize, adSizeClass);
            }
            else if (adSize.AdSizeType == AdSizeType.Fixed)
            {
                adSizeJavaObject = new AndroidJavaObject(AdSizeClassName, adSize.Width, adSize.Height);
            }

            return adSizeJavaObject;
        }

        private static AndroidJavaObject GetFlexibleAdSize(AdSize adSize, AndroidJavaClass adSizeClass)
        {
            AndroidJavaObject adSizeJavaObject;
            if (adSize.Height == AdSize.NotSpecified && adSize.Width == AdSize.NotSpecified)
            {
                adSizeJavaObject = adSizeClass.CallStatic<AndroidJavaObject>(FlexibleSizeMethodName);
            }
            else if (adSize.Height == AdSize.NotSpecified)
            {
                adSizeJavaObject = adSizeClass.CallStatic<AndroidJavaObject>(FlexibleSizeMethodName, adSize.Width);
            }
            else
            {
                adSizeJavaObject = adSizeClass.CallStatic<AndroidJavaObject>(FlexibleSizeMethodName, adSize.Width, adSize.Height);
            }

            return adSizeJavaObject;
        }
    }
}