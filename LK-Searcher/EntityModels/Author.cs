using System.ComponentModel.DataAnnotations;

namespace LK_Searcher.EntityModels
{
    public class Author
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }

        public string Faculty { get; set; }

        public virtual string Department { get; set; }

        public string? ScopusAuthorId { get; set; }

        public string? WOSAuthorId { get; set; }

        public string? SpinCode { get; set; }
        public ICollection<Publish>? Publishes { get; set; } = new List<Publish>();


    }
}
