using Microsoft.ML.Runtime.Api;

namespace hateSpeach.Models
{
    // STEP 1: Data structures models
    
    public class LanguageData
    {
        [Column("0")]
        public string Language;
        [Column("1")]
        public string SentimentText;
    }
    public class SentimentData
    {
        [Column("2")]
        public float Sentiment;
        [Column("1")]
        public string SentimentText;
    }
    // LanguagePrediction is the result returned from prediction operations
    public class LanguagePrediction
    {
        [ColumnName("PredictedLabel")]
        public string PredictedLabels;
    }
    // SentimentPrediction is the result returned from prediction operations
    public class SentimentPrediction
    {
        [ColumnName("PredictedLabel")]
        public bool PredictedLabels;
    }
}