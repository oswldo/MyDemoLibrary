using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyLibraryMVC.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
    }
}