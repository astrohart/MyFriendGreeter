using Core.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PostSharp.Patterns.Diagnostics;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace MyFriendGreeter
{
    /// <summary>
    /// Exposes static methods that are to be used in order to serialize and
    /// deserialize the <c>Friend</c> data to/from JSON.
    /// </summary>
    public static class ConvertFriends
    {
        /// <summary>
        /// Reference to an instance of
        /// <see cref="T:Newtonsoft.Json.JsonSerializerSettings" /> that specifies JSON
        /// configuration settings for the conversion operation.
        /// </summary>
        private static readonly JsonSerializerSettings Settings;

        /// <summary>
        /// Initializes static data or performs actions that need to be performed once only
        /// for the <see cref="T:MyFriendGreeter.ConvertFriends" /> class.
        /// </summary>
        /// <remarks>
        /// This constructor is called automatically prior to the first instance being
        /// created or before any static members are referenced.
        /// </remarks>
        [Log(AttributeExclude = true)]
        static ConvertFriends()
            => Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Formatting = Formatting.Indented,
                Converters =
                {
                    new IsoDateTimeConverter
                    {
                        DateTimeStyles =
                            DateTimeStyles.AssumeUniversal
                    }
                }
            };

        /// <summary>
        /// Parses the specified <paramref name="json" /> content and, if successful,
        /// returns a collection of references to instances of
        /// <see cref="T:MyFriendGreeter.Friend" /> that encapsulate each of the entries in
        /// the specified <paramref name="json" />.
        /// </summary>
        /// <param name="json">(Required.) String containing the JSON content to be parsed.</param>
        /// <returns>
        /// Collection of references to instances of
        /// <see cref="T:MyFriendGreeter.Friend" /> from the entries found in the specified
        /// <paramref name="json" />, or the empty collection otherwise.
        /// </returns>
        [return: NotLogged]
        public static IList<Friend> FromJson([NotLogged] string json)
        {
            IList<Friend> result = default;

            try
            {
                if (string.IsNullOrWhiteSpace(json)) return result;

                result =
                    JsonConvert.DeserializeObject<List<Friend>>(json, Settings);
            }
            catch (Exception ex)
            {
                // dump all the exception info to the log
                DebugUtils.LogException(ex);

                result = default;
            }

            return result;
        }
    }
}