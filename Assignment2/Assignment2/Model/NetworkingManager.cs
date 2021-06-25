using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Model
{
    public class NetworkingManager
    {
        private string url = "https://api.le-systeme-solaire.net/rest/bodies";
        private HttpClient client = new HttpClient();
        private string url2 = "https://api.nasa.gov/planetary/apod?api_key=DEMO_KEY";
        private HttpClient client2 = new HttpClient();
        public List<BodiesData> bodies;

        public async Task<List<BodiesData>> GetAllBodies() {
            var response = await client.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new List<BodiesData>();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var dic = JsonConvert.DeserializeObject<Dictionary<string, object>>(stringResponse);
            var array = dic.ElementAt(0).Value;
            return JsonConvert.DeserializeObject<List<BodiesData>>(array.ToString());
        }

        public async Task<PictureOfDayData> GetPictureOfDay() {
            var response = await client2.GetAsync(url2);

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return new PictureOfDayData();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<PictureOfDayData>(stringResponse);
            return obj;
        }

        public NetworkingManager() { 
        }
    }
}
