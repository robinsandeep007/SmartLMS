using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Web.Models
{
    public class CatagoryModel
    {

        [Key]
        public Guid category_id { get; set; }
        [Required(ErrorMessage = "Catagory Title is required.")]
        public string title { get; set; }
        [Required(ErrorMessage = "Catagory Type is required.")]
        public string type { get; set; }
        public virtual IEnumerable<CourseModel> course { get; set; }


    }
}
