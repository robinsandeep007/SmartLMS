using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Models
{
    public class UserModel
    {
        public Guid userId { get; set; }
        [Required(ErrorMessage = "username is required.")]
        public string username { get; set; }
        public string useremail { get; set; }
        [Required(ErrorMessage = "password is required.")]
        public string password { get; set; }
        public DateTime createdDate { get; set; }
        public bool status { get; set; }
    }
}
