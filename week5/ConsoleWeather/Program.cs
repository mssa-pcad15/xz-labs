
/*
 Use a weather api to get the weather information
 */

using System.Runtime.ConstrainedExecution;

namespace ConsoleWeather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please provide zip code: ");
            string zipCode = Console.ReadLine();

            var requestCurrentWeatherUri = new Uri("https://weather-api167.p.rapidapi.com/api/weather/current?zip=94040%2CUS&units=standard&lang=en&mode=json");

            //create an instance of the http client, who sends http request
            var client = new HttpClient();
            //we also need an instance of http request message (so that this message object exists!!!)
            var request = new HttpRequestMessage
            (
                HttpMethod.Get, //http method
                requestCurrentWeatherUri
            );
            request.Headers.Add("x-rapidapi-key", "44c83c10f0msh6901d759115aebcp169cbbjsnc6c2f7980efa");
            request.Headers.Add("Accept", "application/json"); //give my response in json
            request.Headers.Add("x-rapidapi-host", "weather-api167.p.rapidapi.com"); //represent the endpoint that will handle the request

            HttpResponseMessage response = client.SendAsync(request).Result; //HttpResponseMessage is a class
            response.EnsureSuccessStatusCode(); //this response will throw an exception if the response code is not 300
        
            string responseBodyInJsonString = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(responseBodyInJsonString);
        }
    }
}
