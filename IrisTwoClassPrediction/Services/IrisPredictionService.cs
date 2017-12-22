using IrisTwoClassPrediction.Interfaces;
using IrisTwoClassPrediction.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace IrisTwoClassPrediction.Services
{
    public class IrisPredictionService : IIrisPredictionService
    {
        private readonly IConfiguration _configuration;

        public IrisPredictionService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IrisPlantPredicted[]> GetIrisPrediction(IrisPlantInput irisPlantInput)
        {
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Class", "1"
                                            },
                                            {
                                                "sepal-length", irisPlantInput.SepalLength.ToString()
                                            },
                                            {
                                                "sepal-width", irisPlantInput.SepalWidth.ToString()
                                            },
                                            {
                                                "petal-length", irisPlantInput.PetalLength.ToString()
                                            },
                                            {
                                                "petal-width", irisPlantInput.PetalWidth.ToString()
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                var apiKey = _configuration["IrisApi:ApiKey"];
                var baseUrl = _configuration["IrisApi:BaseAddress"];

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri(baseUrl);

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var objResult = JObject.Parse(result);
                    return JsonConvert.DeserializeObject<IrisPlantPredicted[]>(objResult["Results"]["output1"].ToString());
                }

                return new IrisPlantPredicted[0];
            }
        }
    }
}
