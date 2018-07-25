using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using hateSpeach.Models;
using hateSpeach.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.ML;
using Microsoft.ML.Runtime.LightGBM;

namespace hateSpeach
{
    public class Program
    {

        public static async Task Main(string[] args)
        {
            // workaround to ensure LightGbm assembly is loaded
            //new LightGbmArguments();

            //Uncomment these two lines to train new models, after finish copy .Zip files from bin/Debug folder to the root folder
            //await MLTraining.LanguageTrainAsync();
            //await MLTraining.SentimentTrainAsync();

            MLTraining.LanguageModel = await PredictionModel.ReadAsync<LanguageModel, LanguagePrediction>(DataPath.LanguageModelPath);
            MLTraining.SentimentModel = await PredictionModel.ReadAsync<SentimentModel, SentimentPrediction>(DataPath.SentimentModelPath);

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseKestrel(options => {
                options.Listen(IPAddress.Any, 3000); //HTTP port
            }).UseStartup<Startup>();
    }
}
