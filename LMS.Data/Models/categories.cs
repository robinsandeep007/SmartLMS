using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class categories
    {
        [Key]
        public Guid category_id { get; set; }
        public string title { get; set; }
        public string type { get; set; }
        public virtual IEnumerable<courses> course{ get; set; }
}
}
