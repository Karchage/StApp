using StApp.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Interfaces
{
    public interface IMaterials
    {
        IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);
        Material GetMaterialById(int materialId, bool includeDirectory = false);
        void SaveMaterial(Material material);
        void DeleteMaterial(Material material);
    }
}
