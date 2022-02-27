/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for Unity (C) 2021 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;

namespace YandexMobileAds.Base
{
    public class ImpressionData : EventArgs
    {
        public readonly string rawData;

        public ImpressionData(string rawData){
            this.rawData = rawData;
        }
    }
}    