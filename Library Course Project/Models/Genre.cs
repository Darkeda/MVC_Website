using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Course_Project.Models
{
    public class Genre
    {

        [Key]
        public int GenreId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1)]
        [Display(Name = "Genre")]
        public String GenreName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}