using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintMichel.Model
{
    using System.Text.Json.Serialization;

    public class ShopItem
    {
        [JsonPropertyName("idshop")]
        public int IdShop { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("prix")]
        public double Prix { get; set; }

        [JsonPropertyName("image_url")]
        public string ImageUrl { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }

}
