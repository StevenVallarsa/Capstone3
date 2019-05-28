using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone3.Models
{
    public class Tasks
    {
        public string ID { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}