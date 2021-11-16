using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace Blazor_Authentication.Data.Impl
{
    public class FamilyManager : IFamilyManager
    {
        public Task AddFamily(Family family)
        {
            throw new NotImplementedException();
        }

        public Task RemoveFamily(Family family)
        {
            throw new NotImplementedException();
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

        public Task Update()
        {
            throw new NotImplementedException();
        }

        public Task<Family> GetFamily(int familyId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAdult(int adultId)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Adult>> GetAdults()
        {
            throw new NotImplementedException();
        }

        public Task<Adult> GetAdult(int id)
        {
            throw new NotImplementedException();
        }
    }
}