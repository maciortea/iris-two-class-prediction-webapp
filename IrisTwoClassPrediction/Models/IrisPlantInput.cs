using System.ComponentModel.DataAnnotations;

namespace IrisTwoClassPrediction.Models
{
    public class IrisPlantInput
    {
        [Display(Name = "Sepal length")]
        [Required]
        [RegularExpression(@"^[0-9]\d*(\.\d+)?$", ErrorMessage = "Number has incorrect format.")]
        public double SepalLength { get; set; }

        [Display(Name = "Sepal width")]
        [Required]
        [RegularExpression(@"^[0-9]\d*(\.\d+)?$", ErrorMessage = "Number has incorrect format.")]
        public double SepalWidth { get; set; }

        [Display(Name = "Petal length")]
        [Required]
        [RegularExpression(@"^[0-9]\d*(\.\d+)?$", ErrorMessage = "Number has incorrect format.")]
        public double PetalLength { get; set; }

        [Display(Name = "Petal width")]
        [Required]
        [RegularExpression(@"^[0-9]\d*(\.\d+)?$", ErrorMessage = "Number has incorrect format.")]
        public double PetalWidth { get; set; }
    }
}
