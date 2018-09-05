using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class courses
    {
        [Key]
        public int courseId { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string author { get; set; }
        public bool status { get; set; }
        public DateTime createdDate { get; set; }
        public virtual IEnumerable<units> units { get; set; }

    }
}
