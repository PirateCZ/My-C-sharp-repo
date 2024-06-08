using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine($"Press a key and choose your location.\n1. London\n2. Prague.\n3. Paris\n4. Moscow\n5. Tokyo\n6. Washington\n7. Brazil\n8. CHina\n9. Madagascar");
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        string weatherInCity = "";
        switch (keyInfo.Key)
        {
            case ConsoleKey.D1:
                weatherInCity = "London";
                break;
            case ConsoleKey.D2:
                weatherInCity = "Prague";
                break;
            case ConsoleKey.D3:
                weatherInCity = "Paris";
                break;
            case ConsoleKey.D4:
                weatherInCity = "Moscow";
                break;
            case ConsoleKey.D5:
                weatherInCity = "Tokyo";
                break;
            case ConsoleKey.D6:
                weatherInCity = "Washington";
                break;
            case ConsoleKey.D7:
                weatherInCity = "Brazil";
                break;
            case ConsoleKey.D8:
                weatherInCity = "China";
                break;
            case ConsoleKey.D9:
                weatherInCity = "Madagascar";
                break;
            default:
                Console.WriteLine("Wrong key. Default selected.");
                weatherInCity = "London";
                break;
        }
        string jsonFilePath = "C:\\Users\\fscho\\Documents\\GitHub\\My-C-sharp-repo\\API shit\\Weather App\\Weather App in console\\weatherInfo.json";
        string apiKey = "53c14da4561d74e71719e1b1b78f8a49";
        string urlAPI = $"http://api.openweathermap.org/data/2.5/weather?q={weatherInCity}&appid={apiKey}&units=metric";

        //call api
        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage responseMessage = await client.GetAsync(urlAPI);
            if (responseMessage.IsSuccessStatusCode)
            {
                string jsonResponse = await responseMessage.Content.ReadAsStringAsync();
                File.WriteAllText(jsonFilePath, jsonResponse);

            }
            else Console.WriteLine("\nFailed to fetch weather data");
        }

        //convert .json to .cs
        try
        {
            string jsonFile = File.ReadAllText(jsonFilePath);
            Root root = JsonConvert.DeserializeObject<Root>(jsonFile);

            DateTime utcDateTime = UnixTimeStampToUtcDateTime(root.dt + root.timezone);
            DateTime utcSunriseTime = UnixTimeStampToUtcDateTime(root.sys.sunrise + root.timezone);
            DateTime utcSunsetTime = UnixTimeStampToUtcDateTime(root.sys.sunset + root.timezone);

            //weather app
            Console.WriteLine($"\n" +
                $"You are currently in {root.sys.country} : {root.name}\n" +
                $"Today is {utcDateTime}\n" +
                $"It is currently {root.main.temp}°C and it feels like {root.main.feels_like}°C\n" +
                $"The sun should rise at {utcSunriseTime} and it should set at {utcSunsetTime}\n"
                );

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    public static DateTime UnixTimeStampToUtcDateTime(long unixTimeStamp)
    {
        // Unix timestamp is seconds past epoch
        DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp);
        return dateTimeOffset.UtcDateTime;
    }
}