using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp
{
    public class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if(!context.Directory.Any())
            {
                context.Directory.Add(new Entityes.Directory() { Title = "First", Html = "<h1>First</h1>" });
                context.Directory.Add(new Entityes.Directory() { Title = "Secont", Html = "<h1>Secont</h1>" });
                context.SaveChanges();

                context.Materials.Add(new Entityes.Material() { Title = "First material", Html = "<i>First material</i>", DirectoryId = context.Directory.First().Id });
                context.Materials.Add(new Entityes.Material() { Title = "1 material", Html = "<i>1 material</i>", DirectoryId = context.Directory.First().Id });
                context.Materials.Add(new Entityes.Material() { Title = "Second material", Html = "<i>Second material</i>", DirectoryId = context.Directory.ToList().Last().Id });
                context.SaveChanges();
            }
        }
    }
}
