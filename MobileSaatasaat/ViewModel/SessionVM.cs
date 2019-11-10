using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileSaatasaat.ViewModel
{
    public class SessionVM
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        //public string search { get; set; }
        //public string UserType { get; set; }
        //public bool IsActive { get; set; }
    }
}