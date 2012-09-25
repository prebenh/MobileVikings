using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using GalaSoft.MvvmLight.Messaging;

namespace MobileVikings.BackEnd.Implementation.Repositories
{
    /// <summary>
    /// Base class to connect with the mobile viking API
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T>
        where T : class
    {
        /// <summary>
        /// Gets or sets the URI.
        /// </summary>
        /// <value>
        /// The URI.
        /// </value>
        protected Uri Uri { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        protected Repository()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        /// <param name="uri">The URI.</param>
        protected Repository(string uri)
        {
            Uri = new Uri(uri, UriKind.Absolute);
        }

        /// <summary>
        /// Retrieve a list of T
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> Read()
        {
            var response = await SendRequest();
            if (response == null) return null;
            return DeserializeList(response);
        }

        /// <summary>
        /// Retrieve T
        /// </summary>
        /// <returns></returns>
        public async Task<T> Get()
        {
            var response = await SendRequest();
            if (response == null) return null;

            return DeserializeObject(response);

        }

        private static T DeserializeObject(WebResponse response)
        {
            var json = GetJsonResult(response);
            return JsonConvert.DeserializeObject<T>(json);
        }

        private static List<T> DeserializeList(WebResponse response)
        {
            var json = GetJsonResult(response);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }

        protected static string GetJsonResult(WebResponse response)
        {
            using (var stream = response.GetResponseStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        private async Task<WebResponse> SendRequest()
        {
            try
            {
                var request = MobileVikingsRequest.Create(Uri);
                var response = await request.GetResponseAsync();
                return response;
            }
            catch (WebException exception)
            {
                Messenger.Default.Send<WebException>(exception);
                return null;
            }
        }

    }
}
