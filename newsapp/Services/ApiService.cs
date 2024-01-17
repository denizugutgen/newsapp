using Newtonsoft.Json;
using  static Android.Provider.DocumentsContract;

namespace newsapp.Services
{
    public class ApiService
	{
        public static async Task<Root> GetNews(string categoryName)
        {
			var httpClient = new HttpClient();
			var response = await httpClient.GetStringAsync($"https://gnews.io/api/v4/top-headlines?category={categoryName.ToLower()}&apikey=9a91d2e0ea387970b1dd0e7dfa191783&lang=en");
            return JsonConvert.DeserializeObject<Root>(response);

                
        }
	}
}

