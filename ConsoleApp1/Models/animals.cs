using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp1.Models
{
    public class animal
    { 
        // models
        public int id { get; set; }
        public string full_name { get; set; }
        public int age { get; set; }
        public string owner_name { get; set; }
        public string species { get; set; }

    }
}
