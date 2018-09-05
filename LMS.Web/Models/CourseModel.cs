using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Models
{
    public class CourseModel
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
        public virtual IEnumerable<UnitsModel> units { get; set; }

    }
}
