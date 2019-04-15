using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AzureFunctionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stream = new MemoryStream())
            {
                // Mimic a request by populating the query string
                // Arguments can be passed the same way as a query string is passed in a HTTP request, such as the following:
                // name=John&email=john@example.com
                var request = new MockedHttpRequest();
                request.Body = stream;

                if (args != null && args.Length > 0)
                {
                    var items = args[0].Split('&', StringSplitOptions.RemoveEmptyEntries);

                    Dictionary<string, StringValues> dictionary = items.Select(item => item.Split('=')).ToDictionary(s => s[0], s => new StringValues(s[1]));

                    request.Query = new QueryCollection(dictionary);
                }
                else
                {
                    request.Query = new QueryCollection();
                }

                var logger = new Logger();

                var response = EmailValidationFunction.Run(request, logger).Result;

                Console.WriteLine(((ObjectResult)response).Value);
                Console.ReadKey();
            }
        }
    }
}
