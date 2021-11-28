using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DataAccess.Data;
using Models;

namespace Data.Impl
{
	public class FamilyManager : IFamilyManager
	{
		private readonly string ROOT = "https://localhost:5003";

		public async Task AddFamily(Family family)
		{
			using HttpClient client = new();

			string familyAsJson = JsonSerializer.Serialize(family);

			StringContent content = new StringContent(
			familyAsJson,
			Encoding.UTF8,
			"application/json"
				);
			HttpResponseMessage responseMessage = await client.PostAsync($"{ROOT}/FamilyService", content);
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

		}

		public async Task RemoveFamily(Family family)
		{
			using HttpClient client = new();
			HttpResponseMessage responseMessage = await client.DeleteAsync($"{ROOT}/FamilyService/{family.FamilyId}");
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
		}

		public async Task<IList<Family>> GetFamilies()
		{
			using HttpClient client = new();

			HttpResponseMessage responseMessage = await client.GetAsync("{ROOT}/FamilyService");

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
				await client.PatchAsync($"{ROOT}/FamilyService/UpdateFamily", content);

			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
		}

		public async Task<Family> GetFamily(int familyId)
		{
			using HttpClient client = new();

			HttpResponseMessage responseMessage = await client.GetAsync($"{ROOT}/FamilyService/{familyId}");

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
			HttpResponseMessage responseMessage = await client.DeleteAsync($"{ROOT}/FamilyService/adult/{adultId}");
			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
		}

		public async Task<IList<Adult>> GetAdults()
		{
			using HttpClient client = new();

			HttpResponseMessage responseMessage = await client.GetAsync("{ROOT}/FamilyService/adults");

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

			HttpResponseMessage responseMessage = await client.GetAsync($"{ROOT}/FamilyService/adult/{id}");

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
				await client.PatchAsync($"{ROOT}/FamilyService/UpdateAdult", content);

			if (!responseMessage.IsSuccessStatusCode)
				throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");

		}
	}
}