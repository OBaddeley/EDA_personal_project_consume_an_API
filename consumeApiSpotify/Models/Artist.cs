using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace consumeApiSpotify.Models
{
    public class Artist
    {
        [JsonProperty(PropertyName = "artists")]
        public List<ArtistInfo> ArtistsInfo { get; set; } 
    }
}