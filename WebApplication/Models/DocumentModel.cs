using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class DocumentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Access { get; set; }
        public string UserName { get; set; }
    }
    public class DocumentCreateModel
    {
        public bool Access { get; set; }
    }
}