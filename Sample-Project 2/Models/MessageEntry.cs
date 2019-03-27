using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample_Project_2.Models
{
    public class MessageEntry
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public bool Edited { get; set; }
    }
}