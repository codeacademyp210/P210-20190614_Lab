using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ResumeTemplate.Models
{
    public class HomeViewModel
    {
        public List<Education> Educations { get; set; }
        public List<Experience> Experiences{ get; set; }
    }
}