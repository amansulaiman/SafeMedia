using hateSpeach.Models;
using Microsoft.ML;
using System.Threading.Tasks;

namespace hateSpeach.Services
{
    public class MLPrediction
    {
        public static async Task<string> PredictLanguageAsync(LanguageData predictData)
        {
            if (MLTraining.LanguageModel == null)
            {
                MLTraining.LanguageModel = await MLTraining.LanguageTrainAsync();
            }
            var prediction = MLTraining.LanguageModel.Predict(predictData);
            return prediction.PredictedLabels;
        }
    }
}