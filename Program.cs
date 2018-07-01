using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using hateSpeach.Models;
using hateSpeach.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ML;

namespace hateSpeach
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            try
            {
                MLTraining.LanguageModel = await PredictionModel.ReadAsync<LanguageData, LanguagePrediction>(DataPath.LanguageModelPath);
            }
            catch (Exception)
            {
                MLTraining.LanguageModel = await MLTraining.LanguageTrainAsync();
            }
            //TODO Sentiment also
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
