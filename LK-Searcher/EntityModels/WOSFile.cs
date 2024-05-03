using System.ComponentModel.DataAnnotations;

namespace LK_Searcher.EntityModels
{
    public class WOSFile
    {
        [Key]
        public int Id { get; set; }
        public string PublishTitle { get; set; }
        public string SourceTitle { get; set; }
        public string DocumentType { get; set; }
        public int PublishYear { get; set; }
    }
}
