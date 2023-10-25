using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Zipcode;

public class RestService
{
    HttpClient _client;

    public RestService()
    {
        _client = new HttpClient();
    }

    public async Task<ZipCode> GetZipCodeData(string query)
    {
        ZipCode zipData = null;
        try
        {
            var response = await _client.GetAsync(query);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                zipData = JsonConvert.DeserializeObject<ZipCode>(content);
                JObject d = JObject.Parse(content);
                Debug.WriteLine(d.Property("Title"));
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine("\t\tERROR {0}", ex.Message);
        }

        return zipData;
    }
}

