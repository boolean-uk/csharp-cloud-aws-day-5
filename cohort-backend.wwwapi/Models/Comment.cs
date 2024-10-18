using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cohort_backend.wwwapi.Models
{
    [Table("comments")]
    public class Comment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [ForeignKey("posts")]
        public int PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("users")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
