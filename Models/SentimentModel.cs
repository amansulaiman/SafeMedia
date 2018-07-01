using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace hateSpeach.Models
{
    public class SentimentModel
    {
        public string Language { get; set; }
        public bool IsHateSpeech { get; set; }
        public string Suggestion { get; set; }
    }
}
