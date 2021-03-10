using Newtonsoft.Json;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AmiboPedia.ViewModel {

    //This is to make our ensure our class can handle anything, since T is generic 
    public class HttpHelper<T> {
        public async Task<T> GetRestServiceData(string ServiceURL) {
            using (HttpClient client = new HttpClient()) {

                client.BaseAddress = new Uri(ServiceURL);
                var jsonDataResponse = await client.GetAsync(client.BaseAddress);
                if (jsonDataResponse.IsSuccessStatusCode) {
                    var jsonResult = await jsonDataResponse.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<T>(jsonResult);
                    return result;
                }
                return default;
            }
        }
    }
}
