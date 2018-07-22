using System;
using System.ComponentModel.DataAnnotations;

namespace hateSpeach.Models
{
    public class HateSpeechReportViewModel
    {
        [Required]
        public string HateText { get; set; } 
        [Display(Description="e.g Facebook")]
        public string Source { get; set; }
        public string EvidanceLink { get; set; }
        [Display(Description="e.g muslims")]
        public string Target { get; set; }
        public Language Language { get; set; }
        public Category Category { get; set; }
    }
    public class HateSpeechReport:BaseModel
    {
        public string HateText { get; set; } 
        public string Source { get; set; }
        public string EvidanceLink { get; set; }
        public string Target { get; set; }
        public Language Language { get; set; }
        public Category Category { get; set; }  
    }
    public class BaseModel
    {
        public BaseModel() { Id = Guid.NewGuid().ToString(); CreatedAt = new DateTimeOffset(DateTime.Now);}

        public string Id { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
    }
    public enum Language
    {
        HAUSA, ENLISH
    }
    public enum Category
    {
        GENDER_BASE_VIOLENCE,
        FARMERS_HERDSMEN,
        ETHNICITY,
        POVERTY,
        BIAFRA,
        ELECTION,
        INTRA_RELIGION,
        BOKO_HARAM,
        INTER_RELIGION,
        POLITICS
    }
}
