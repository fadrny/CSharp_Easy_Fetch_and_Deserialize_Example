using System;
using System.Net;
using System.IO;


namespace FetchData
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();

            // Add a user agent header in case the
            // requested URI contains a query.

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead("https://catfact.ninja/fact");
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            data.Close();
            reader.Close();

            Console.WriteLine("JSON: " + s);

            var objectWithFields = System.Text.Json.JsonSerializer.Deserialize<CatFact>(s);
            Console.WriteLine("\r\nDélka je: " + objectWithFields.length);
            Console.ReadKey();
        }
    }
}
