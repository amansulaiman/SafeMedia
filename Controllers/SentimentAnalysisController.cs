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

                return Ok("");
            }
            return NotFound("Invalid text");
        }
    }
}