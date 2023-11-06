using System.Text.Json.Serialization;

namespace MarvelApi.Modals
{
    public class HeroiModal
    {
        public class Result
        {
            [JsonPropertyName("id")]
            public int? Id { get; set; }

            [JsonPropertyName("name")]
            public string? NomeHeroi { get; set; }

            [JsonPropertyName("description")]
            public string? Descricao { get; set; }

            [JsonPropertyName("thumbnail")]
            public Thumbnail? Thumbnail { get; set; }

            [JsonPropertyName("events")]
            public Events? Eventos { get; set; }

        }

        public class Events
        {
            [JsonPropertyName("available")]
            public int? Available { get; set; }

            [JsonPropertyName("collectionURI")]
            public string? CollectionURI { get; set; }

            [JsonPropertyName("items")]
            public List<Item>? Items { get; set; }

            [JsonPropertyName("returned")]
            public int? Returned { get; set; }
        }

        public class Item
        {
            [JsonPropertyName("resourceURI")]
            public string? ResourceURI { get; set; }

            [JsonPropertyName("name")]
            public string? NomeEvento { get; set; }

            [JsonPropertyName("type")]
            public string? Tipo { get; set; }
        }

        public class Thumbnail
        {
            [JsonPropertyName("path")]
            public string? Path { get; set; }

            [JsonPropertyName("extension")]
            public string? Extension { get; set; }
        }
    }
}
