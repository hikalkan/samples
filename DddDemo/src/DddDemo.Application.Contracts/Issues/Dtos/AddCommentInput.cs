using System.ComponentModel.DataAnnotations;

namespace DddDemo.Issues.Dtos
{
    public class AddCommentInput
    {
        [Required]
        [MaxLength(128)]
        public string IssueId { get; set; }

        [Required]
        [MaxLength(65536)]
        public string Message { get; protected set; }
    }
}