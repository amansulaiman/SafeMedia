using System.Threading.Tasks;
using hateSpeach.Models;
using hateSpeach.Services;
using Microsoft.AspNetCore.Mvc;

namespace hateSpeach.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    public class SentimentAnalysisController:Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sentiment">Sentiment Text to run analysis</param>
        /// <response code ="400">Invalid text</response>
        /// <response code ="404">Language not supported</response>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult<SentimentModel>> Train(string sentiment)
        {
            if (sentiment != string.Empty && sentiment != null)
            {
                return Ok("Successfull");
            }
            return NotFound("Invalid text");
        }
    }
}