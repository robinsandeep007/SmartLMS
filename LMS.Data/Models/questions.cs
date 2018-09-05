using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class questions
    {
        [Key]
        public int questionId { get; set; }
        public string question { get; set; }
        public bool type { get; set; }
        public bool status { get; set; }
        public units unit { get; set; }
        public IEnumerable<choices> choice { get; set; }
    }
}
