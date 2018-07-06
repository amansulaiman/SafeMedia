using Microsoft.ML.Runtime.Api;

namespace hateSpeach.Models
{
    // STEP 1: Data structures models
    
    public class DataModel
    {
        [Column("0")]
        public string Language;
        [Column("1")]
        public string SentimentText;
        [Column("2")]
        public float Sentiment;
    }
    // LanguagePrediction is the result returned from prediction operations
    public class LanguagePrediction
    {
        [ColumnName("Score")]
        public float[] Score;
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