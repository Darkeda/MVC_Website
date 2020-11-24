using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Library_Course_Project.Models
{
    public class Writer
    {

        [Key]
        public int WriterId { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 1)]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [StringLength(200, MinimumLength = 1)]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Display(Name = "Pen Name")]
        public String UserName { get; set; }

        public virtual ICollection<Book> Books { get; set; }

    }
}