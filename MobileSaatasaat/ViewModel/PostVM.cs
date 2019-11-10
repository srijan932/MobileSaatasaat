using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MobileSaatasaat.ViewModel
{
    public class PostVM
    {
        [Key]
        [Column(Order = 0)]

        public int PostId { get; set; }


        [Column(Order = 1)]
        [StringLength(100)]
        public string Title { get; set; }


        [Column(Order = 2)]
        public string Description { get; set; }


        [Column(Order = 3)]
        public string Image { get; set; }

        [Column(Order = 4)]
        public string ImageOfBox { get; set; }

        [Column(Order = 5)]
        public string ImageOfMobile { get; set; }

        [Column(Order = 6)]
        public string Price { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }
    }
}