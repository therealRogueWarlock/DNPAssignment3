using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Data;
using DataAccess.model;
using Models;

namespace Data.Impl
{
    public class ApiUserService : IUserService
    {
        
        public async Task<User> ValidateUser(string userName, string Password)
        {
            
            using HttpClient client = new();
            
            User userInfo = new User();
            userInfo.UserName = userName;
            userInfo.Password = Password;
            
            string userInfoAsJSON = JsonSerializer.Serialize(userInfo);
            
            StringContent content = new StringContent(
                userInfoAsJSON,
                Encoding.UTF8,
                "application/json"
            );
            
            HttpResponseMessage responseMessage = 
                await client.PostAsync($"https://localhost:5003/Login", content);
            
            if (!responseMessage.IsSuccessStatusCode)
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            
            string result = await responseMessage.Content.ReadAsStringAsync();

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            
            
            return user;
            
        }
    }
}