using StApp.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Interfaces
{
    public interface IDirectory
    {
        IEnumerable<Directory> GetAllDirectorys(bool includeMaterial = false);
        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory directory);
        void DeleteDerectory(Directory directory);
    }
}
