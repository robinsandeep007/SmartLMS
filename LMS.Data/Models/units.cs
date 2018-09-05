using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class units
    {
        [Key]
        public int unitId { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public int timeSpent { get; set; }
        public string compStatus { get; set; }
        public string score { get; set; }
        public bool status { get; set; }
        public DateTime createdDate { get; set; }
        public courses course { get; set; }
        public virtual IEnumerable<questions> question { get; set; }

    }
}
