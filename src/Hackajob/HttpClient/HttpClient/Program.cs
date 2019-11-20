using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Search("Luke Skywalker").GetAwaiter().GetResult());

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.ReadKey();


            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }

        static async Task<int> Search(string character)
        {
            using (var httpClient = new System.Net.Http.HttpClient())
            {
                var response = await httpClient.GetAsync($"https://challenges.hackajob.co/swapi/api/people/?search={WebUtility.UrlEncode(character)}");
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();

                using (var reader = new JsonTextReader(new StringReader(responseString)))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    var deserialized = (JObject) jsonSerializer.Deserialize(reader);
                    if ((int) deserialized.GetValue("count") != 1)
                    {
                        throw new FormatException("Invalid response");
                    }

                    var results = (JArray)deserialized["results"];
                    return ((JArray) results[0]["films"]).Count;
                }
            }
        }
    }
}
