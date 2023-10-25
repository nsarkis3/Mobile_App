using Newtonsoft.Json;

namespace Zipcode;
public class ZipCode
{
    [JsonProperty("country abbreviation")]
    public string countryAbv { get; set; }
    public Place[] places { get; set; }
    public string country { get; set; }
    [JsonProperty("place name")]
    public string placeName { get; set; }
    public string state { get; set; }
    [JsonProperty("state abbreviation")]
    public string stateAbv { get; set; }
}
public class Place
{
    [JsonProperty("place name")]
    public string placeName { get; set; }
    public double longitude { get; set; }
    [JsonProperty("post code")]
    public int postalCode { get; set; }
    public double latitude { get; set; }

}
