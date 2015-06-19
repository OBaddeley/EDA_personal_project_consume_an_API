using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace consumeApiSpotify.Models
{
    public class ApiDAL
    {
        private Uri baseUri = new Uri("http://ws.spotify.com/");
        //  search/1/artist.json?q=beyonce

        public List<ArtistInfo> GetMusicInfo(string search)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = baseUri;

                var result = client.GetAsync(string.Format("search/1/artist.json?q={0}", search)).Result;
                string resultContent = result.Content.ReadAsStringAsync().Result;

                var returnInfo = apiSerialiser(resultContent);
                return returnInfo;

            }
        }

        public List<ArtistInfo> apiSerialiser(string json)
        {
            var musicResult = JsonConvert.DeserializeObject<Artist>(json);
            var result = new List<ArtistInfo>();

            foreach (var item in musicResult.ArtistsInfo)
            {
               result.Add(new ArtistInfo() {href = item.href, name= item.name, popularity = item.popularity});
            }

            return result;
        } 

    }
}