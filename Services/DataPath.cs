using System;
using System.IO;

namespace hateSpeach.Services
{
    public class DataPath
    {
        public static string AppPath => Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        public static string TrainDataPath => Path.Combine(AppPath, "datasets", "data_train.txt");
        public static string TestDataPath => Path.Combine(AppPath,  "datasets", "data_test.txt");
        public static string LanguageModelPath => Path.Combine(AppPath, "LanguageModel.zip");
        public static string SentimentModelPath => Path.Combine(AppPath, "SentimentModel.zip");
        public static string ONNXPath => Path.Combine(AppPath, "ONNX", "LanguageModel.onnx");
        public static string ONNXJsonPath => Path.Combine(AppPath, "ONNX", "SafeMedia.json"); 
    }
}