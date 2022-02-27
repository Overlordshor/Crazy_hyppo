/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for Unity (C) 2018 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

namespace YandexMobileAds.Base
{
    
    public enum AdSizeType
    {
        Fixed,
        Flexible,
        Sticky
    }

    // The size of banner ad.
    public class AdSize
    {
        public const int NotSpecified = -1;

        public static readonly AdSize BANNER_240x400 = new AdSize {Width = 240, Height = 400, AdSizeType = AdSizeType.Fixed};
        public static readonly AdSize BANNER_300x250 = new AdSize {Width = 300, Height = 250, AdSizeType = AdSizeType.Fixed};
        public static readonly AdSize BANNER_300x300 = new AdSize {Width = 300, Height = 300, AdSizeType = AdSizeType.Fixed};
        public static readonly AdSize BANNER_320x50 = new AdSize {Width = 320, Height = 50, AdSizeType = AdSizeType.Fixed};
        public static readonly AdSize BANNER_320x100 = new AdSize {Width = 320, Height = 100, AdSizeType = AdSizeType.Fixed};
        public static readonly AdSize BANNER_400x240 = new AdSize {Width = 400, Height = 240, AdSizeType = AdSizeType.Fixed};
        public static readonly AdSize BANNER_728x90 = new AdSize {Width = 728, Height = 90, AdSizeType = AdSizeType.Fixed};

        public int Width { get; private set; }
        public int Height { get; private set; }
        public AdSizeType AdSizeType { get; private set; }

        public static AdSize StickySize(int width)
        {
            return new AdSize {Width = width, Height = NotSpecified, AdSizeType = AdSizeType.Sticky};
        }

        public static AdSize FlexibleSize()
        {
            return new AdSize {Width = NotSpecified, Height = NotSpecified, AdSizeType = AdSizeType.Flexible};
        }

        public static AdSize FlexibleSize(int width)
        {
            return new AdSize {Width = width, Height = NotSpecified, AdSizeType = AdSizeType.Flexible};
        }

        public static AdSize FlexibleSize(int width, int height)
        {
            return new AdSize {Width = width, Height = height, AdSizeType = AdSizeType.Flexible};
        }
    }
}