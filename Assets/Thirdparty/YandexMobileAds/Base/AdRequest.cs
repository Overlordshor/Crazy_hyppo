/*
 * This file is a part of the Yandex Advertising Network
 *
 * Version for Unity (C) 2018 YANDEX
 *
 * You may not use this file except in compliance with the License.
 * You may obtain a copy of the License at https://legal.yandex.com/partner_ch/
 */

using System;
using System.Collections.Generic;

namespace YandexMobileAds.Base
{
    // AdRequest contains targeting information used to fetch ad.
    public class AdRequest
    {
        /// <summary>
        /// User's age for targeting process.
        /// </summary>
        /// <value>The string representation of user's age.</value>
        public string Age { get; private set; }
        
        // Сurrent user query entered inside app.
        public string ContextQuery { get; private set; }

        // Tags describing current user context inside app.
        public List<string> ContextTags { get; private set; }

        /// <summary>
        /// User's gender for targeting process.
        /// </summary>
        /// <value>The string representation of user's gender.</value>
        public string Gender { get; private set; }

        //  User's Location for targeting process.
        public Location Location { get; private set; }

        // Custom Parameters.
        public Dictionary<string, string> Parameters { get; private set; }

        private AdRequest(Builder builder)
        {
            this.Age = builder.Age;
            this.ContextQuery = builder.ContextQuery;

            if (builder.ContextTags != null)
            {
                this.ContextTags = new List<string>(builder.ContextTags);
            }

            this.Gender = builder.Gender;
            this.Location = builder.Location;

            if (builder.Parameters != null)
            {
                this.Parameters = new Dictionary<string, string>(builder.Parameters);
            }
        }

        public class Builder
        {

            internal string Age { get; private set; }

            internal string ContextQuery { get; private set; }

            internal List<string> ContextTags { get; private set; }

            internal string Gender { get; private set; }

            internal Location Location { get; private set; }

            internal Dictionary<string, string> Parameters { get; private set; }

            // Sets user's Age for targeting process.
            public Builder WithAge(string age)
            {
                this.Age = age;
                return this;
            }

            // Sets current user query entered inside app.
            public Builder WithContextQuery(string contextQuery)
            {
                this.ContextQuery = contextQuery;
                return this;
            }

            // Sets tags describing current user context inside app.
            public Builder WithContextTags(List<string> contextTags)
            {
                this.ContextTags = contextTags;
                return this;
            }

            // Sets user's Gender for targeting process.
            public Builder WithGender(string gender)
            {
                this.Gender = gender;
                return this;
            }

            // Sets user's Location for targeting process.
            public Builder WithLocation(Location location)
            {
                this.Location = location;
                return this;
            }

            // Sets custom Parameters.
            public Builder WithParameters(Dictionary<string, string> parameters)
            {
                this.Parameters = parameters;
                return this;
            }

            public Builder WithAdRequest(AdRequest adRequest)
            {
                if (adRequest != null) 
                {
                    this.ContextQuery = adRequest.ContextQuery;
                    this.ContextTags = adRequest.ContextTags;
                    this.Parameters = adRequest.Parameters;
                    this.Location = adRequest.Location;
                    this.Age = adRequest.Age;
                    this.Gender = adRequest.Gender;
                }
                return this;
            }

            public AdRequest Build()
            {
                if (this.Parameters == null) 
                {
                    this.Parameters = new Dictionary<string, string>();
                }
                return new AdRequest(this);
            }
        }
    }
}