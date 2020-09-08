using StApp.Controllers;
using StApp.Entityes;
using StApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace StApp.Services
{
    public class DirectoryService
    {
        private DataManager DataManager;
        private MaterialService _materialService;
        public DirectoryService(DataManager dataManager)
        {
            DataManager = dataManager;
            _materialService = new MaterialService(dataManager);
        }

        public List<DirectoryViewModel> GetDirectoriesList()
        {
            var _dir = DataManager.Directorys.GetAllDirectorys();
            List<DirectoryViewModel> _modelsList = new List<DirectoryViewModel>();
            foreach (var item in _dir)
            {
                _modelsList.Add(DirectoryDBToViewModelById(item.Id));
            }
            return _modelsList;
        }

        public DirectoryViewModel DirectoryDBToViewModelById(int directoryId)
        {
            var _dir = DataManager.Directorys.GetDirectoryById(directoryId, true);
            List<MaterialViewModel> _materialList = new List<MaterialViewModel>();
            foreach(var item in _dir.Materials)
            {
                _materialList.Add(_materialService.MaterialDBModelToView(item.Id));
            }
            return new DirectoryViewModel() { Directory = _dir, Materials = _materialList};
        }

        public DirectoryViewModel SaveDirectoryToDb(DirectoryViewModel directoryViewModel)
        {
            var _dir = directoryViewModel.Directory;
            DataManager.Directorys.SaveDirectory(_dir);
            directoryViewModel.Directory = _dir;
            return directoryViewModel;
        }

        public DirectoryEditModel GetDirectoryEditModel(int directoryId)
        {
            if(directoryId != 0)
            {
                var _dirDB = DataManager.Directorys.GetDirectoryById(directoryId);
                var _dirEdit = new DirectoryEditModel() {
                    Id = _dirDB.Id,
                    Title = _dirDB.Title,
                    Html = _dirDB.Html
                };
                return _dirEdit;
            }
            else { return new DirectoryEditModel() { }; }
        }
        
        public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
        {
            Directory _dir;
            if(directoryEditModel.Id != 0)
            {
                _dir = DataManager.Directorys.GetDirectoryById(directoryEditModel.Id);
                
            }
            else
            {
                _dir = new Directory();
            }
            _dir.Title = directoryEditModel.Title;
            _dir.Html = directoryEditModel.Html;

            DataManager.Directorys.SaveDirectory(_dir);

            return DirectoryDBToViewModelById(_dir.Id);
        }
    }
}
