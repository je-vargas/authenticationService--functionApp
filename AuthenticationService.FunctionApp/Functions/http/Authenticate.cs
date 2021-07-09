using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using AuthenticationService.FunctionApp.Models.Requests;

namespace AuthenticationService.FunctionApp
{
    public static class Authenticate
    {
        [FunctionName(nameof(Authenticate))]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, nameof(HttpMethods.Get), Route = "user")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            AuthenicateUserRequest authenticateUserRequest = null;

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            authenticateUserRequest = JsonConvert.DeserializeObject<AuthenicateUserRequest>(content);

            string responseMessage = string.IsNullOrEmpty(authenticateUserRequest.Username)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {authenticateUserRequest.Username}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
