using hateSpeach.Models;
using Microsoft.ML;
using System.Threading.Tasks;

namespace hateSpeach.Services
{
    public class MLPrediction
    {
        public static async Task<string> PredictLanguageAsync(LanguageModel predictData)
        {
            if (MLTraining.LanguageModel == null)
            {
                MLTraining.LanguageModel = await MLTraining.LanguageTrainAsync();
            }
            var prediction = MLTraining.LanguageModel.Predict(predictData);
            return prediction.PredictedLabels;
        }
        public static async Task<bool> PredictSentimentAsync(SentimentModel predictData)
        {
            if (MLTraining.SentimentModel == null)
            {
                MLTraining.SentimentModel = await MLTraining.SentimentTrainAsync();
            }
            var prediction = MLTraining.SentimentModel.Predict(predictData);
            return prediction.PredictedLabels;
        }
    }
}