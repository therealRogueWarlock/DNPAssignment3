using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Blazor_Authentication.Data;
using Models;

namespace Data.Impl
{
    public class FamilyManager : IFamilyManager
    {
        public async Task AddFamily(Family family)
        {
            using HttpClient client = new();

            string familyAsJson = JsonSerializer.Serialize(family);

            StringContent content = new StringContent(
            familyAsJson,
            Encoding.UTF8,
            "application/json"
                );
            HttpResponseMessage responseMessage = await client.PostAsync($"https://localhost:5003/FamilyService", content);
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

        }

        public async Task RemoveFamily(Family family)
        {
            using HttpClient client = new();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:5003/FamilyService/{family.Id}");
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task<IList<Family>> GetFamilies()
        {
            using HttpClient client = new();

            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5003/FamilyService");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            IList<Family> families = JsonSerializer.Deserialize<IList<Family>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return families;
            
        }

        public async Task UpdateFamily(Family family)
        {
            using HttpClient client = new();

            string familyAsJson = JsonSerializer.Serialize(family); 

            StringContent content = new StringContent(
                familyAsJson,
                Encoding.UTF8,
                "application/json"
            );
            HttpResponseMessage responseMessage = 
                await client.PatchAsync($"https://localhost:5003/FamilyService/UpdateFamily", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task<Family> GetFamily(int familyId)
        {
            using HttpClient client = new();

            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5003/FamilyService/{familyId}");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            Family family = JsonSerializer.Deserialize<Family>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return family;
        }

        public async Task RemoveAdult(int adultId)
        {
            using HttpClient client = new();
            HttpResponseMessage responseMessage = await client.DeleteAsync($"https://localhost:5003/FamilyService/adult/{adultId}");
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
        }

        public async Task<IList<Adult>> GetAdults()
        {
            using HttpClient client = new();

            HttpResponseMessage responseMessage = await client.GetAsync("https://localhost:5003/FamilyService/adults");

            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

            string result = await responseMessage.Content.ReadAsStringAsync();

            IList<Adult> adults = JsonSerializer.Deserialize<IList<Adult>>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
        
            return adults;
        }

        public async Task<Adult> GetAdult(int id)
        {
            using HttpClient client = new();

            HttpResponseMessage responseMessage = await client.GetAsync($"https://localhost:5003/FamilyService/adult/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"{responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            Adult adult = JsonSerializer.Deserialize<Adult>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return adult;
        }

        public async Task UpdateAdult(Adult adult)
        {
            using HttpClient client = new();

            string adultAsJson = JsonSerializer.Serialize(adult); 
            StringContent content = new StringContent(
                adultAsJson,
                Encoding.UTF8,
                "application/json"
            );
            
            HttpResponseMessage responseMessage = 
                await client.PatchAsync($"https://localhost:5003/FamilyService/UpdateAdult", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
        }
    }
}