using System;
using System.Threading.Tasks;
using hateSpeach.Models;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Models;
using Microsoft.ML.Runtime.LightGBM;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;
namespace hateSpeach.Services
{
    public class MLTraining
    {
        public static PredictionModel<LanguageModel, LanguagePrediction> LanguageModel;

        public static PredictionModel<SentimentModel, SentimentPrediction> SentimentModel;

        public static async Task<PredictionModel<LanguageModel, LanguagePrediction>> LanguageTrainAsync()
        {
            // LearningPipeline holds all steps of the learning process: data, transforms, learners.
            var pipeline = new LearningPipeline();

            // The TextLoader loads a dataset. The schema of the dataset is specified by passing a class containing
            // all the column names and their types.
            pipeline.Add(new TextLoader(DataPath.TrainDataPath).CreateFrom<LanguageModel>());
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training
            pipeline.Add(new Dictionarizer(("Language", "Label")));

            // Puts all features into a vector
            pipeline.Add(new TextFeaturizer("Features", "SentimentText"));
            
            // Add a learning algorithm to the pipeline. 
            // This is a classification scenario (What type of language is this?)
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            // Convert the Label back into original text (after converting to number using Dictionarizer)
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

            // The pipeline is trained on the dataset that has been loaded and transformed.
            var model = pipeline.Train<LanguageModel, LanguagePrediction>();

            //Evaluate model
            EvaluateLanguage(model);

            // Saving the model as a .zip file.
            await model.WriteAsync(DataPath.LanguageModelPath);
            // OnnxConverter onx = new OnnxConverter()
            // {
            //     Name = "LanguageModel.onnx",
            //     Onnx= DataPath.ONNXPath,
            //     Json= DataPath.ONNXJsonPath,
            //     Domain = "SafeMedia"
            // };
            // onx.Convert(model); 
            return model;
        }

        private static void EvaluateLanguage(PredictionModel<LanguageModel, LanguagePrediction> model)
        {
            // To evaluate how good the model predicts values, the model is ran against new set
            // of data (test data) that was not involved in training.
            var testData = new TextLoader(DataPath.TestDataPath).CreateFrom<LanguageModel>();
            
            // ClassificationEvaluator .
            var evaluator = new ClassificationEvaluator ();
            
            Console.WriteLine("=============== Evaluating model ===============");

            var metrics = evaluator.Evaluate(model, testData);
            Console.WriteLine("Metrics:");
            Console.WriteLine($"    AccuracyMacro = {metrics:0.####}, a value between 0 and 1, the closer to 1, the better");
            Console.WriteLine($"    AccuracyMicro = {metrics.AccuracyMicro:0.####}, a value between 0 and 1, the closer to 1, the better");

            Console.WriteLine("=============== End evaluating ===============");
            Console.WriteLine();
        }

        public static async Task<PredictionModel<SentimentModel, SentimentPrediction>> SentimentTrainAsync()
        {
            // LearningPipeline holds all steps of the learning process: data, transforms, learners.
            var pipeline = new LearningPipeline();
            // The TextLoader loads a dataset. The schema of the dataset is specified by passing a class containing
            // all the column names and their types.
            
           pipeline.Add(new TextLoader(DataPath.TrainDataPath).CreateFrom<SentimentModel>());
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training

            // Puts all features into a vector
            pipeline.Add(new TextFeaturizer("Features", "SentimentText"));
            //pipeline.Add(new WordEmbeddings("", ""){ModelKind = WordEmbeddingsTransformPretrainedModelKind.FastTextWikipedia300D});
            // FastTreeBinaryClassifier is an algorithm that will be used to train the model.
            // It has three hyperparameters for tuning decision tree performance. 
            pipeline.Add(new FastTreeBinaryClassifier() {NumLeaves = 128, NumTrees = 100, MinDocumentsInLeafs = 10});
            //LightGbmBinaryClassifier
            // The pipeline is trained on the dataset that has been loaded and transformed.
            var model = pipeline.Train<SentimentModel, SentimentPrediction>();

            //Evaluate model
            EvaluateSentiment(model);

            // Saving the model as a .zip file.
            await model.WriteAsync(DataPath.SentimentModelPath);

            return model;
        }

        private static void EvaluateSentiment(PredictionModel<SentimentModel, SentimentPrediction> model)
        {
            // To evaluate how good the model predicts values, the model is ran against new set
            // of data (test data) that was not involved in training.
            var testData = new TextLoader(DataPath.TestDataPath).CreateFrom<SentimentModel>();
            
            // BinaryClassificationEvaluator performs evaluation for Binary Classification type of ML problems.
            var evaluator = new BinaryClassificationEvaluator();

            Console.WriteLine("=============== Evaluating model ===============");

            var metrics = evaluator.Evaluate(model, testData);
            // BinaryClassificationMetrics contains the overall metrics computed by binary classification evaluators
            // The Accuracy metric gets the accuracy of a classifier which is the proportion 
            //of correct predictions in the test set.

            // The Auc metric gets the area under the ROC curve.
            // The area under the ROC curve is equal to the probability that the classifier ranks
            // a randomly chosen positive instance higher than a randomly chosen negative one
            // (assuming 'positive' ranks higher than 'negative').

            // The F1Score metric gets the classifier's F1 score.
            // The F1 score is the harmonic mean of precision and recall:
            //  2 * precision * recall / (precision + recall).

            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.Auc:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("=============== End evaluating ===============");
            Console.WriteLine();
        }
    }
}