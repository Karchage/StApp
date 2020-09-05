using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using StApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StApp.Enums.PageEnums;

namespace StApp.Controllers
{
    public class PageController : Controller
    {
        private DataManager DataManager;
        private ServicesManager ServicesManager;

        public PageController(DataManager dataManager)
        {
            DataManager = dataManager;
            ServicesManager = new ServicesManager(dataManager);
        }

        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageType.Directory: _viewModel = ServicesManager.Directorys.DirectoryDBToViewModelById(pageId); break;
                case PageType.Material: _viewModel = ServicesManager.Materials.MaterialDBModelToView(pageId); break;
                default: _viewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_viewModel);
        }

        public IActionResult PageEditor(int pageId, PageType pageType)
        {
            PageEditModel _editModel;
            switch(pageType)
            {
                case PageType.Directory: _editModel = ServicesManager.Directorys.GetDirectoryEditModel(pageId); break; 
                case PageType.Material: _editModel = ServicesManager.Materials.GetMaterialEditModel(pageId);break;
                default: _editModel = null;break;
            }
            ViewBag.PageType = pageType;
            return View(_editModel);
        }
    }
}
