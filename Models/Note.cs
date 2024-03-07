
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApiApp.Models
{
    [Table("Notes")]
    public class NotesTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNote { get; set; }
        public string? TitleNote { get; set; }
        public string? TextNote { get; set; }
        public DateTime? DateCreate { get; set; }
    }
}
