using System.Threading.Tasks;
using hateSpeach.Services;
using Microsoft.AspNetCore.Mvc;

namespace hateSpeach.Controllers
{
    [Route("api/[controller]")]
    public class SentimentController:Controller
    {
        [HttpGet("[action]")]
        public async Task<IActionResult> Train()
        {
            await MLTraining.LanguageTrainAsync();
            return Ok("Done");
        }
    }
}