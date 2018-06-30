using Microsoft.ML.Runtime.Api;

namespace hateSpeach.Models
{
    public class LanguagePrediction
    {
        [ColumnName("PredictedLanguage")]
        public int Language;
    }
}