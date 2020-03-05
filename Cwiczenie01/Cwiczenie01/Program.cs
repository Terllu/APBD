using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Cwiczenie01
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            //if (args.Length == 0) return;

            var client = new HttpClient();
            var result = await client.GetAsync("https://www.pja.edu.pl");
            //Task<T>
            //ThreadPool()

            if (!result.IsSuccessStatusCode) return;

            string html = await result.Content.ReadAsStringAsync();
            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z.]+", RegexOptions.IgnoreCase);
            var matches = regex.Matches(html);
            foreach(var m in matches)
            {
                Console.WriteLine(m);
            }


            Console.WriteLine("Koniec!");
        }
    }
}
