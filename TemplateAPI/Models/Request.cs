using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TemplateAPI.Models
{
    public class Request
    {
        [Key]
        public int Id { get; set; }

        public int TemplateId { get; set; }
        public string Json { get; set; }
        public DateTime CreationDate { get; set; }
        public string Version { get; set; }
    }
}