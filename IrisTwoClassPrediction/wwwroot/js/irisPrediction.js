var IrisPrediction = function () {
    predictionComplete = function (result) {
        if (!result || result.status !== 200) {
            $('#IrisPredictionModal .modal-body').html('An error has occured.');
        } else {
            var predictedPlant = '';
            if (result.responseJSON && result.responseJSON.length > 0) {
                predictedPlant = result.responseJSON[0]['Scored Labels'];
            }

            $('#IrisPredictionModal .modal-body').html('Predicted Iris Plant: <strong>' + predictedPlant + '</strong>');
        }

        $('#IrisPredictionModal').modal();
    };

    return {
        predictionComplete: predictionComplete
    };
}();
