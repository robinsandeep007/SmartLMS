using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LMS.Data.Models
{
    public class attempts
    { 
        [Key]
        public int attemptId { get; set; }
        public int noAttempts { get; set; }
        public int score { get; set; }
        public string time { get; set; }
    }
}
