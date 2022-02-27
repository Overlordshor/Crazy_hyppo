/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for iOS (C) 2018 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;

namespace YandexMobileAds.Common
{
    public interface IMobileAdsClient
    {
        /// <summary>
        /// Set a value indicating whether user from GDPR region allowed to collect personal data 
        /// which is used for analytics and ad targeting. 
        /// If the value is set to false personal data will not be collected.
        /// </summary>
        /// <param name="consent"><c>true</c> if user provided consent to collect personal data, otherwise <c>false</c>.</param>
        void SetUserConsent(bool consent);
    }
}
