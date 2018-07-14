using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hateSpeach.Models;
using hateSpeach.Services;
using Microsoft.AspNetCore.Mvc;
using SafeMedia.Models;

namespace hateSpeach.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class SentimentAnalysisController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentiment">Sentiment Text to run analysis</param>
        /// <response code ="400">Invalid text</response>
        /// <response code ="404">Language not supported</response>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult<SentimentViewModel>> Train(string sentiment)
        {
            if (sentiment != string.Empty && sentiment != null)
            {
                var predictedLanguage = await MLPrediction.PredictLanguageAsync(new LanguageModel() { SentimentText = sentiment });
                var predictedSentiment = await MLPrediction.PredictSentimentAsync(new SentimentModel() { SentimentText = sentiment });
                float LanguageConfidance = 0.0f;
                if (predictedLanguage.PredictedLabels == "HAUSA")
                {
                    LanguageConfidance = predictedLanguage.Score[0] * 100;
                }
                if (predictedLanguage.PredictedLabels == "ENGLISH")
                {
                    LanguageConfidance = predictedLanguage.Score[1] * 100;
                }
                float hateSpeachConfidance = 0.0f;
                if (predictedSentiment.PredictedLabels)
                {
                    hateSpeachConfidance = predictedSentiment.Score * 100;
                }else
                {
                    hateSpeachConfidance = 0;
                }
                string suggestion = string.Empty;
                if (predictedLanguage.PredictedLabels == "HAUSA" && predictedSentiment.PredictedLabels)
                {
                    suggestion = "Ka dan gyara kalamanka domin za su iya cutar da wani";
                }
                if (predictedLanguage.PredictedLabels == "ENGLISH" && predictedSentiment.PredictedLabels)
                {
                    suggestion = "Please refine your world they might be offensive to others";
                }
                return Ok(new SentimentViewModel(){
                    Language = predictedLanguage.PredictedLabels, LanguageConfidance = LanguageConfidance, IsHateSpeech = predictedSentiment.PredictedLabels, HateSpeechConfidance = hateSpeachConfidance, Suggestion = suggestion 
                });
            }
            return NotFound("Invalid text");
        }

        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        
        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}