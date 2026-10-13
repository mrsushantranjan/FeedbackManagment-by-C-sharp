using System.ComponentModel.DataAnnotations;

namespace FeedbackManagement.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your name.")]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Full Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your email.")]
        [EmailAddress(ErrorMessage = "Enter a valid email address.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a rating.")]
        [Range(1, 5, ErrorMessage = "Rating must be from 1 to 5.")]
        public int Rating { get; set; }

        [Required(ErrorMessage = "Please enter your comments.")]
        [StringLength(500, MinimumLength = 5,
            ErrorMessage = "Comments must be 5 to 500 characters.")]
        public string Comments { get; set; } = string.Empty;
    }
}