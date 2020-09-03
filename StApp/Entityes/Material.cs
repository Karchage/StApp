using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Entityes
{
    public class Material : Page
    {
        public int DirectoryId { get; set; } // key
        public Directory Directory { get; set; } // navigation 
    }
}
