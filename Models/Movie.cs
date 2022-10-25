using System.ComponentModel.DataAnnotations;

namespace movie_api.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 60 characters")]
        [MinLength(3,  ErrorMessage = "This field must contain between 3 and 60 characters")]
        public string? Name { get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 60 characters")]
        [MinLength(3,  ErrorMessage = "This field must contain between 3 and 60 characters")]
        public string? Description { get; set;}

        [Required(ErrorMessage = "This field is required")]
        [MaxLength(30, ErrorMessage = "This field must contain between 3 and 60 characters")]
        [MinLength(3,  ErrorMessage = "This field must contain between 3 and 60 characters")]
        public string? MovieType { get; set;}
    }
}