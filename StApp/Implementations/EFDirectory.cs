using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using StApp.Entityes;
using StApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Implementations
{
    public class EFDirectory : IDirectory
    {
        private EFDBContext context;
        public EFDirectory(EFDBContext context)
        {
            this.context = context;
        }
        public void DeleteDirectory(Directory directory)
        {
            context.Directory.Remove(directory).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Directory> GetAllDirectorys(bool includeMaterial = false)
        {
            if(includeMaterial)
            {
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().ToList();
            }
            else
            {
                return context.Directory.ToList();
            }
        }

        public Directory GetDirectoryById(int directoryId, bool includeMaterials = false)
        {
            if(includeMaterials)
            {
                return context.Set<Directory>().Include(x => x.Materials).AsNoTracking().FirstOrDefault(x => x.Id == directoryId);
            }
            else
            {
                return context.Directory.FirstOrDefault(x => x.Id == directoryId);
            }
        }

        public void SaveDirectory(Directory directory)
        {
            if(directory.Id == 0)
            {
                context.Directory.Add(directory).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            }
            else
            {
                context.Entry(directory).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
