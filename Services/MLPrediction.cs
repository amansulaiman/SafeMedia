using hateSpeach.Models;
using Microsoft.ML;
using System.Threading.Tasks;

namespace hateSpeach.Services
{
    public class MLPrediction
    {
        public static async Task<LanguagePrediction> PredictLanguageAsync(LanguageModel predictData)
        {
            if (MLTraining.LanguageModel == null)
            {
                MLTraining.LanguageModel = await MLTraining.LanguageTrainAsync();
            }
            var prediction = MLTraining.LanguageModel.Predict(predictData);
            return prediction;
        }
        public static async Task<SentimentPrediction> PredictSentimentAsync(SentimentModel predictData)
        {
            if (MLTraining.SentimentModel == null)
            {
                MLTraining.SentimentModel = await MLTraining.SentimentTrainAsync();
            }
            var prediction = MLTraining.SentimentModel.Predict(predictData);
            return prediction;
        }
    }
}