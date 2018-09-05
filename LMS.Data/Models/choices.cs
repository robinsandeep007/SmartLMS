using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class choices
    {
        [Key]
        public int choiceId { get; set; }
        public string choice { get; set; }
        public bool isCorrect { get; set; }
        public string type { get; set; }
        public questions question { get; set; }
    }
}
