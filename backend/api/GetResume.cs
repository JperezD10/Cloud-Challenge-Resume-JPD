using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net;

namespace api
{
    public static class GetResume
    {
        [FunctionName("GetResume")]
        public static HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpResponseMessage req,
            [CosmosDB(databaseName:"AzureResume",containerName:"Counter",Connection ="AzureResumeConnectionString",Id ="1", PartitionKey ="1")] Counter counter,
            [CosmosDB(databaseName:"AzureResume",containerName:"Counter",Connection ="AzureResumeConnectionString",Id ="1", PartitionKey = "1")] out Counter updatedCounter,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            updatedCounter = counter;
            updatedCounter.Count++;
            var jsonToReturn = JsonConvert.SerializeObject(updatedCounter);


            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(jsonToReturn, System.Text.Encoding.UTF8, "application/json")
            };

            response.Headers.Add("Access-Control-Allow-Origin", "*");
            response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS");
            response.Headers.Add("Access-Control-Allow-Headers", "Content-Type, Authorization");


            return response;
        }
    }
}
