﻿using static MarvelApi.Modals.HeroiModal;

namespace MarvelApi.Dtos
{
    public class HeroiResponse
    {
        public int? Id { get; set; }

        public string? NomeHeroi { get; set; }

        public string? Descricao { get; set; }

        public Thumbnail? Thumbnail { get; set; }

        public Events? Eventos { get; set; }
    }

    public class Events
    {
        public int? Available { get; set; }

        public string? CollectionURI { get; set; }

        public List<Item>? Items { get; set; }
    }

    public class Item
    {
        public string? ResourceURI { get; set; }

        public string? NomeEvento { get; set; }

        public string? Tipo { get; set; }
    }

    public class Thumbnail
    {
        public string? Path { get; set; }

        public string? Extension { get; set; }
    }
}
