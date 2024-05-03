using System.ComponentModel.DataAnnotations.Schema;

namespace LK_Searcher.EntityModels
{
    public class Publish
    {
        public int Id { get; set; }

        public ICollection<Author> Authors { get; set; } = new List<Author>();
        public string PublishTitle { get; set; }
        public string SourceTitle { get; set; }
        public string DocumentType { get; set; }
        public int PublishYear { get; set; }
        public int? WOSFileId { get; set; }
        [ForeignKey("WOSFileId")]
        public WOSFile? WOSFile { get; set; }
        public string State { get; set; } = "На рассмотрении";
        public int? ScopusFileId { get; set; }
        [ForeignKey("ScopusFileId")]
        public ScopusFile? ScopusFile { get; set; }


    }
}
