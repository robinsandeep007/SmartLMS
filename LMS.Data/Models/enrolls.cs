using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class enrolls
    {
        [Key]
        public int enrollId { get; set; }
        public bool enrollstatus { get; set; }
        public bool status { get; set; }
        public DateTime createdDate { get; set; }
        public users user { get; set; }
        public courses course { get; set; }
    }
}
