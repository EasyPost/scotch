﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EasyPost.EasyVCR.Tests
{
    public class Album
    {
        internal int Id { get; }
        internal string Title { get; }
        internal int UserId { get; }

        public Album(int userId, int id, string title)
        {
            UserId = userId;
            Id = id;
            Title = title;
        }
    }

    public class AlbumService
    {
        private readonly HttpClient? _client;
        private readonly VCR? _vcr;

        public HttpClient Client
        {
            get
            {
                if (_client != null) return _client;

                if (_vcr != null) return _vcr.Client;

                throw new InvalidOperationException("No VCR or HttpClient has been set.");
            }
        }

        public AlbumService(VCR vcr)
        {
            _vcr = vcr;
        }

        public AlbumService(HttpClient client)
        {
            _client = client;
        }

        public async Task<IList<Album>?> GetAllAsync()
        {
            var response = await Client.GetAsync("https://jsonplaceholder.typicode.com/albums");
            var jsonString = await response.Content.ReadAsStringAsync();

            var albums = JsonConvert.DeserializeObject<IList<Album>>(jsonString);

            return albums;
        }

        public async Task<Album?> GetAsync(int id)
        {
            var url = $"https://jsonplaceholder.typicode.com/albums/{id}";
            var response = await Client.GetAsync(url);
            var jsonString = await response.Content.ReadAsStringAsync();

            var album = JsonConvert.DeserializeObject<Album>(jsonString);

            return album;
        }
    }
}
