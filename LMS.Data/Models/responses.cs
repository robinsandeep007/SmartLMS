using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class responses
    {
        [Key]
        public int responseId { get; set; }
        public users user { get; set; }
        public questions question { get; set; }
        public choices choice { get; set; }
        public bool isCorrect { get; set; }
        public string response { get; set; }
        public virtual attempts attempt { get; set; }
    }
}
