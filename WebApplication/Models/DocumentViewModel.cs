using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DocumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public bool Access { get; set; }
        public string UserName { get; set; }
    }
}