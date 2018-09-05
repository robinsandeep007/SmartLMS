using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class users
    {
        [Key]
        public Guid userId { get; set; }
        public string username { get; set; }
        public string useremail { get; set; }
        public string password { get; set; }
        public DateTime createdDate { get; set; }
        public bool status { get; set; }
    }
}
