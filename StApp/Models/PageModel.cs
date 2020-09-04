using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Models
{
    public abstract class PageEditModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Html { get; set; }
    }

    public abstract class PageViewModel
    {

    }
}
