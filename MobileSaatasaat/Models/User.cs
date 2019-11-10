using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileSaatasaat.Models
{
    public class User
    {
        [Key]
        [Column(Order = 0)]

        public int UserId { get; set; }


        [Column(Order = 1)]
        [StringLength(100)]
        public string FullName { get; set; }


        [Column(Order = 2)]
        [StringLength(50)]
        public string Email { get; set; }


        [Column(Order = 3)]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        public bool? IsAdmin { get; set; }

    }
}