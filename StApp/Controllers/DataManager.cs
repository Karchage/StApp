using StApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Controllers
{
    public class DataManager
    {
        private IDirectory _dictionary;
        private IMaterials _materials;
        public DataManager(IDirectory dictionary, IMaterials materials)
        {
            _dictionary = dictionary;
            _materials = materials;
        }

        public IDirectory Directorys { get { return _dictionary; } }
        public IMaterials Materials { get { return _materials; } }
    }
}
