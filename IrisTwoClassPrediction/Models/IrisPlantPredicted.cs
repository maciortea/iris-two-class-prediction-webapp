using Newtonsoft.Json;

namespace IrisTwoClassPrediction.Models
{
    public class IrisPlantPredicted
    {
        [JsonProperty("Class")]
        public int DesiredOutput { get; set; }

        [JsonProperty("Scored Labels")]
        public int PredictedOutput { get; set; }

        [JsonProperty("sepal-length")]
        public double SepalLength { get; set; }

        [JsonProperty("sepal-width")]
        public double SepalWidth { get; set; }

        [JsonProperty("petal-length")]
        public double PetalLength { get; set; }

        [JsonProperty("petal-width")]
        public double PetalWidth { get; set; }
    }
}
