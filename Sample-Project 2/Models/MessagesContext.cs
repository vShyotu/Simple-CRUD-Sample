﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Sample_Project_2.Models
{
    public class MessagesContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MessagesContext() : base("name=MessagesContext")
        {
        }

        public System.Data.Entity.DbSet<Sample_Project_2.Models.MessageEntry> MessageEntries { get; set; }
    }
}
