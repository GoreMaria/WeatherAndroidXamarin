using System.Net.Http;
using System.Threading.Tasks;

namespace WeatherAndroidXamarin.Service.Networking
{
    public class RestClient:IRestClient
    {
        public async Task<string> GetAsync(string uri)
        {
            var httpClient = new HttpClient();
            var adress = httpClient.BaseAddress;
            var responce = await httpClient.GetAsync(uri).ConfigureAwait(false);
            var content = await responce.Content.ReadAsStringAsync();
            return content;
        }
    }
}