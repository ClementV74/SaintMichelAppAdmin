
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net.Http;
using System.Text.Json;

namespace SaintMichel.Services
{
    public class GenericApiService<T> where T : class
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;
        protected string GetUrl(string method) => $"{_baseUrl}/{method}";

        public GenericApiService(string baseUrl)
        {
            _httpClient = new HttpClient();
            _baseUrl = baseUrl;
        }


        public async Task<bool> AddItemAsync(T item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(_baseUrl, content);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateItemAsync(string id, T item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}+/Put{typeof(T).Name}/{id}", content);
            // warn response .IsSuccessStatusCode;
            await Application.Current.MainPage.DisplayAlert("Warning", response.IsSuccessStatusCode.ToString(), "OK");

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<T> GetItemAsync(string id)
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/Get{typeof(T).Name}ById/{id}");
      
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<T>(json);
            }
            return null;
        }

        public async Task<IEnumerable<T>> GetItemsAsync()
        {
            var response = await _httpClient.GetAsync($"{_baseUrl}/GetAll{typeof(T).Name}");


            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<IEnumerable<T>>(json);
            }

            return Enumerable.Empty<T>();
        }
    


        // Méthodes Spécifiques à ShopItem
        public async Task<List<ShopItem>> GetAllShopItemsAsync()
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}/getAllShop");
            return JsonSerializer.Deserialize<List<ShopItem>>(response);
        }

        public async Task<ShopItem> GetShopItemByIdAsync(int id)
        {
            var response = await _httpClient.GetStringAsync($"{_baseUrl}/getShopById/{id}");
            return JsonSerializer.Deserialize<ShopItem>(response);
        }

        public async Task DeleteShopItemAsync(int itemId)
        {
            var response = await _httpClient.DeleteAsync($"{_baseUrl}/deleteShop/{itemId}");

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erreur lors de la suppression de l'article avec l'ID {itemId}");
            }
        }

        public async Task UpdateShopItemAsync(ShopItem item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"{_baseUrl}/updateShop/{item.IdShop}", content);
            response.EnsureSuccessStatusCode();
        }

        public async Task AddShopItemAsync(ShopItem item)
        {
            var json = JsonSerializer.Serialize(item);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"{_baseUrl}/addShop", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Erreur lors de l'ajout de l'article");
            }
        }


        
    }
}

