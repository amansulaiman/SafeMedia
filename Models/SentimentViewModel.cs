using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SafeMedia.Models
{
    public class SentimentViewModel
    {
        public string Language { get; set; }
        public float LanguageConfidance { get; set; }
        public bool IsHateSpeech { get; set; }
        public float HateSpeechConfidance { get; set; }
        public string Suggestion { get; set; }
    }
}
