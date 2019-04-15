using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AzureFunctionExample
{
    public class EmailValidationFunction
    {
        public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a new email request.");

            string email = req.Query["email"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            email = email ?? data?.email;

            if (email == null)
            {
                return new BadRequestObjectResult("Please pass an email address on the query string or in the request body");
            }
            else
            {
                bool blnValidEmail = Regex.IsMatch(email, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$",
                            RegexOptions.IgnoreCase,
                            TimeSpan.FromMilliseconds(250));


                return new OkObjectResult("Email status: " + blnValidEmail);
            }
        }
    }
}
