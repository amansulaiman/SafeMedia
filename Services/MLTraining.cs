using System;
using System.Threading.Tasks;
using hateSpeach.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace hateSpeach.Services
{
    public class MLTraining
    {
        internal static async Task<PredictionModel<DataModel, LanguagePrediction>> LanguageTrainAsync()
        {
            // LearningPipeline holds all steps of the learning process: data, transforms, learners.
            var pipeline = new LearningPipeline();
            // The TextLoader loads a dataset. The schema of the dataset is specified by passing a class containing
            // all the column names and their types.
           pipeline.Add(new TextLoader(DataPath.TrainDataPath).CreateFrom<DataModel>(useHeader:true, separator:','));
                
            // Transforms
            // When ML model starts training, it looks for two columns: Label and Features.
            // Label:   values that should be predicted. If you have a field named Label in your data type,
            //              like in this example, no extra actions required.
            //          If you don’t have it, copy the column you want to predict with ColumnCopier transform:
            //              new ColumnCopier(("FareAmount", "Label"))
            // Features: all data used for prediction. At the end of all transforms you need to concatenate
            //              all columns except the one you want to predict into Features column with
            //              ColumnConcatenator transform:

            pipeline.Add(new Dictionarizer((("Language", "Label"))));
            pipeline.Add(new TextFeaturizer("Features", "SentimentText"));
                // StochasticDualCoordinateAscentClassifier is an algorithm that will be used to train the model.
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLanguage" });
            
            // The pipeline is trained on the dataset that has been loaded and transformed.
            var model = pipeline.Train<DataModel, LanguagePrediction>();

            // Saving the model as a .zip file.
            await model.WriteAsync(DataPath.LanguageModelPath);
            
            return model;
        }
        private static void LanguageEvaluate(PredictionModel<DataModel, LanguagePrediction> model)
        {
            // To evaluate how good the model predicts values, the model is ran against new set
            // of data (test data) that was not involved in training.
            var testData = new TextLoader(DataPath.TestDataPath).CreateFrom<DataModel>();
            
            // ClassificationEvaluator .
            var evaluator = new ClassificationEvaluator ();
            
            Console.WriteLine("=============== Evaluating model ===============");

            var metrics = evaluator.Evaluate(model, testData);
            Console.WriteLine("Metrics:");
            //Console.WriteLine($"    AccuracyMacro = {metrics:0.####}, a value between 0 and 1, the closer to 1, the better");
            Console.WriteLine($"    AccuracyMicro = {metrics.AccuracyMicro:0.####}, a value between 0 and 1, the closer to 1, the better");
            //Console.WriteLine($"    LogLoss = {metrics.LogLoss:0.####}, the closer to 0, the better");
            // Console.WriteLine($"    LogLoss for class 1 = {metrics.PerClassLogLoss[0]:0.####}, the closer to 0, the better");
            // Console.WriteLine($"    LogLoss for class 2 = {metrics.PerClassLogLoss[1]:0.####}, the closer to 0, the better");
            // Console.WriteLine($"    LogLoss for class 3 = {metrics.PerClassLogLoss[2]:0.####}, the closer to 0, the better");
            // Console.WriteLine();
            // Console.WriteLine($"    ConfusionMatrix:");

            // // Print confusion matrix
            // for (var i = 0; i < metrics.ConfusionMatrix.Order; i++)
            // {
            //     for (var j = 0; j < metrics.ConfusionMatrix.ClassNames.Count; j++)
            //     {
            //         Console.Write("\t" + metrics.ConfusionMatrix[i, j]);
            //     }
            //     Console.WriteLine();
            // }

            Console.WriteLine("=============== End evaluating ===============");
            Console.WriteLine();
        }
    }
}