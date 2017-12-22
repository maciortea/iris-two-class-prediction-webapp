using IrisTwoClassPrediction.Models;
using System.Threading.Tasks;

namespace IrisTwoClassPrediction.Interfaces
{
    public interface IIrisPredictionService
    {
        Task<IrisPlantPredicted[]> GetIrisPrediction(IrisPlantInput irisPlantInput);
    }
}
