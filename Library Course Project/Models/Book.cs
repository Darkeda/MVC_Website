using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Course_Project.Models
{
    public class Book
    {

        [Key]
        public int BookId { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 1)]
        public String Title { get; set; }

        [Display(Name = "Release Date")]
        [DataType(dataType: DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public int? WriterId { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [StringLength(500, MinimumLength = 1)]
        public String Description { get; set; }

        
        public virtual Writer Writer { get; set; }
        public virtual Genre Genre { get; set; }
    }
}