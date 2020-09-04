using StApp.Entityes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Models
{
    public class MaterialViewModel : PageViewModel
    {
        public Material Material { get; set; }
        public Material NextMaterial { get; set; }

    }
    public class MaterialEditModel : PageEditModel
    {
        [Required]
        public int DirectoryId { get; set; }
    }
}
