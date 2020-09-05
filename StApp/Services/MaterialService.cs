using StApp.Controllers;
using StApp.Entityes;
using StApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Services
{
    public class MaterialService
    {
        private DataManager DataManager;
        public MaterialService(DataManager dataManager)
        {
            DataManager = dataManager;
        }
        public MaterialViewModel MaterialDBModelToView(int materialId)
        {
            var _mat = new MaterialViewModel()
            {
                Material = DataManager.Materials.GetMaterialById(materialId),
            };
            var _dir = DataManager.Directorys.GetDirectoryById(_mat.Material.DirectoryId);
            if(_dir.Materials.IndexOf(_mat.Material) != _dir.Materials.Count())
            {
                _mat.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_mat.Material) + 1);
            }
            return _mat;
        }

        public MaterialEditModel GetMaterialEditModel(int materialId)
        {
            var _dbModel = DataManager.Materials.GetMaterialById(materialId);
            var _editModel = new MaterialEditModel() { 
                Id=_dbModel.Id,
                DirectoryId = _dbModel.DirectoryId,
                Title = _dbModel.Title,
                Html = _dbModel.Html,
            };
            return _editModel;
        }

        public MaterialViewModel SaveMaterialEditModelToDB(MaterialEditModel editModel)
        {
            Material material;
            if(editModel.Id != 0)
            {
                material = DataManager.Materials.GetMaterialById(editModel.Id);
            }
            else
            {
                material = new Material();
            }
            material.Title = editModel.Title;
            material.Html = editModel.Html;
            material.DirectoryId = editModel.DirectoryId;
            DataManager.Materials.SaveMaterial(material);
            return MaterialDBModelToView(material.Id);
        }
    }
}
