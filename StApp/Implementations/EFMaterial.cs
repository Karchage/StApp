using Microsoft.EntityFrameworkCore;
using StApp.Entityes;
using StApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Implementations
{
    public class EFMaterial : IMaterials
    {
        private EFDBContext context;
        public EFMaterial(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteMaterial(Material material)
        {
            context.Materials.Remove(material).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
            {
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            }
            else
            {
                return context.Materials.ToList();
            }
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
            {
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().FirstOrDefault(x => x.Id == materialId);
            }
            else
            {
                return context.Materials.FirstOrDefault(x => x.Id == materialId);
            }
        }

        public void SaveMaterial(Material material)
        {
            if(material.Id == 0)
            {
                context.Materials.Add(material).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(material).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
