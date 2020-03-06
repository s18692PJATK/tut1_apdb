using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tutorial_Crawler
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            var websiteUrl = args.Length> 0 ? args[0] : throw new ArgumentNullException();

            if (websiteUrl == null) throw new ArgumentException();


            try
            {
                var httpClient = new HttpClient();

                var response = await httpClient.GetAsync(websiteUrl);
                //var x = websiteUrl ?? throw new Exception();


                if (response.IsSuccessStatusCode)
                {
                    var htmlContent = await response.Content.ReadAsStringAsync();
                    var regex = new Regex("[a-z)+[a-z0-9]*@[[a-z0-9]+\\.[a-z]+", RegexOptions.IgnoreCase);
                    var emails = regex.Matches(htmlContent);

                    if (emails.Count == 0)
                    {
                        Console.WriteLine("no emails found");
                        return;
                    }

                    foreach (var email in emails)
                    {
                        Console.WriteLine(email.ToString());
                    }

                    httpClient.Dispose();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("error while downloading the page");
            }


                Console.WriteLine();
                Console.WriteLine("something");
            }




        }

        
    }
}
