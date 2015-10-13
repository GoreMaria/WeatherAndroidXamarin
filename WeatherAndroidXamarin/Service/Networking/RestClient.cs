using System.Threading.Tasks;

namespace WeatherAndroidXamarin.Service.Networking
{
    public class RestClient:IRestClient
    {
        public async Task<string> GetAsync(string uri)
        {

            var httpClient = new HttpC
            var responce = await httpClient.GetAsync(uri);
            var content = await responce.Content.ReadAsStringAsync();
            return content;
        }
    }
}