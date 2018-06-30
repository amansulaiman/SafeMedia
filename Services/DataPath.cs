using System;
using System.IO;

namespace hateSpeach.Services
{
    public class DataPath
    {
        public static string AppPath => System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
        public static string TrainDataPath => System.IO.Path.Combine(AppPath, "datasets", "data.csv");
        public static string TestDataPath => System.IO.Path.Combine(AppPath,  "datasets", "data_test.csv");
        public static string LanguageModelPath => System.IO.Path.Combine(AppPath, "LanguageModel.zip");
    }
}