using System.Diagnostics;
using System.Threading.Tasks;
using IrisTwoClassPrediction.Interfaces;
using IrisTwoClassPrediction.Models;
using Microsoft.AspNetCore.Mvc;

namespace IrisTwoClassPrediction.Controllers
{
    public class IrisPredictionController : Controller
    {
        private readonly IIrisPredictionService _irisPredictionService;

        public IrisPredictionController(IIrisPredictionService irisPredictionService)
        {
            _irisPredictionService = irisPredictionService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = new IrisPlantInput
            {
                SepalLength = 1D,
                SepalWidth = 1D,
                PetalLength = 1D,
                PetalWidth = 1D
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PredictIrisPlant(IrisPlantInput irisPlantInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var irisPlantPredicted = await _irisPredictionService.GetIrisPrediction(irisPlantInput);
            return Json(irisPlantPredicted);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}