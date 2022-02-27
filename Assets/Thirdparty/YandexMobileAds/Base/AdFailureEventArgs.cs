/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for Unity (C) 2018 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;

namespace YandexMobileAds.Base
{
    // Event that occurs when ad fails to perform action.
    public class AdFailureEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}