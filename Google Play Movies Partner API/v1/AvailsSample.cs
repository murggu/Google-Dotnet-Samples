﻿// Copyright 2017 DAIMTO :  www.daimto.com
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
// the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
// an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
// specific language governing permissions and limitations under the License.
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by DAIMTO-Google-apis-Sample-generator 1.0.0
//     Template File Name:  Methodtemplate.tt
//     Build date: 01/02/2017 22:33:26
//     C# generater version: 1.0.0
//     
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
  
// About 
// 
// Unoffical sample for the PlayMovies v1 API for C#. 
// This sample is designed to be used with the Google .Net client library. (https://github.com/google/google-api-dotnet-client)
// 
// API Description: Gets the delivery status of titles for Google Play Movies Partners.
// API Documentation Link https://developers.google.com/playmoviespartner/
//
// Discovery Doc  https://www.googleapis.com/discovery/v1/apis/PlayMovies/v1/rest
//
//------------------------------------------------------------------------------
// Installation
//
// This sample code uses the Google .Net client library 
//
// NuGet package:
//
// Location: https://www.nuget.org/packages/Google.Apis.PlayMovies.v1/ 
// Install Command: PM>  Install-Package Google.Apis.PlayMovies.v1
//
//------------------------------------------------------------------------------  
using Google.Apis.PlayMovies.v1;
using Google.Apis.PlayMovies.v1.Data;
using System;

namespace GoogleSamplecSharpSample.PlayMoviesv1.Methods
{
  
    public static class AvailsSample
    {


        /// <summary>
        /// Get an Avail given its avail group id and avail id. 
        /// Documentation https://developers.google.com/playmovies/v1/reference/avails/get
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated PlayMovies service.</param>  
        /// <param name="accountId">REQUIRED. See _General rules_ for more information about this field.</param>
        /// <param name="availId">REQUIRED. Avail ID.</param>
        /// <returns>AvailResponse</returns>
        public static Avail Get(PlayMoviesService service, string accountId, string availId)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (accountId == null)
                    throw new ArgumentNullException(accountId);
                if (availId == null)
                    throw new ArgumentNullException(availId);

                // Make the request.
                return service.Avails.Get(accountId, availId).Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Avails.Get failed.", ex);
            }
        }

        public class AvailsListOptionalParms
        {
            /// See _List methods rules_ for info about this field.
            public int PageSize { get; set; }  
            /// See _List methods rules_ for info about this field.
            public string PageToken { get; set; }  
            /// See _List methods rules_ for info about this field.
            public string PphNames { get; set; }  
            /// See _List methods rules_ for info about this field.
            public string StudioNames { get; set; }  
            /// Filter that matches Avails with a `title_internal_alias`, `series_title_internal_alias`, `season_title_internal_alias`, or `episode_title_internal_alias` that contains the given case-insensitive title.
            public string Title { get; set; }  
            /// Filter Avails that match (case-insensitive) any of the given country codes, using the "ISO 3166-1 alpha-2" format (examples: "US", "us", "Us").
            public string Territories { get; set; }  
            /// Filter Avails that match a case-insensitive, partner-specific custom id. NOTE: this field is deprecated and will be removed on V2; `alt_ids` should be used instead.
            public string AltId { get; set; }  
            /// Filter Avails that match any of the given `video_id`s.
            public string VideoIds { get; set; }  
            /// Filter Avails that match (case-insensitive) any of the given partner-specific custom ids.
            public string AltIds { get; set; }  
        
        }
 
        /// <summary>
        /// List Avails owned or managed by the partner. See _Authentication and Authorization rules_ and _List methods rules_ for more information about this method. 
        /// Documentation https://developers.google.com/playmovies/v1/reference/avails/list
        /// Generation Note: This does not always build corectly.  Google needs to standardise things I need to figuer out which ones are wrong.
        /// </summary>
        /// <param name="service">Authenticated PlayMovies service.</param>  
        /// <param name="accountId">REQUIRED. See _General rules_ for more information about this field.</param>
        /// <param name="optional">Optional paramaters.</param>        /// <returns>ListAvailsResponseResponse</returns>
        public static ListAvailsResponse List(PlayMoviesService service, string accountId, AvailsListOptionalParms optional = null)
        {
            try
            {
                // Initial validation.
                if (service == null)
                    throw new ArgumentNullException("service");
                if (accountId == null)
                    throw new ArgumentNullException(accountId);

                // Building the initial request.
                var request = service.Avails.List(accountId);

                // Applying optional parameters to the request.                
                request = (AvailsResource.ListRequest)SampleHelpers.ApplyOptionalParms(request, optional);

                // Requesting data.
                return request.Execute();
            }
            catch (Exception ex)
            {
                throw new Exception("Request Avails.List failed.", ex);
            }
        }

        
	}
		public static class SampleHelpers
    {

        /// <summary>
        /// Using reflection to apply optional parameters to the request.  
        /// 
        /// If the optonal parameters are null then we will just return the request as is.
        /// </summary>
        /// <param name="request">The request. </param>
        /// <param name="optional">The optional parameters. </param>
        /// <returns></returns>
        public static object ApplyOptionalParms(object request, object optional)
        {
            if (optional == null)
                return request;

            System.Reflection.PropertyInfo[] optionalProperties = (optional.GetType()).GetProperties();

            foreach (System.Reflection.PropertyInfo property in optionalProperties)
            {
                // Copy value from optional parms to the request.  They should have the same names and datatypes.
                System.Reflection.PropertyInfo piShared = (request.GetType()).GetProperty(property.Name);
				if (property.GetValue(optional, null) != null) // TODO Test that we do not add values for items that are null
					piShared.SetValue(request, property.GetValue(optional, null), null);
            }

            return request;
        }
    }
}