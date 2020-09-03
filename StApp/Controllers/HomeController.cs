using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StApp.Entityes;
using StApp.Models;

namespace StApp.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext _context;
        private DataManager _dataManager;
        public HomeController(EFDBContext context, DataManager dataManager)
        {
            //_context = context;
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            //MyHomeModel _model = new MyHomeModel() { HelloMessage = "Hello world" };
            //List<Directory> _dirs = _context.Directory.Include(dir => dir.Materials).ToList();
            List<Directory> _dirs = _dataManager.Directorys.GetAllDirectorys(true).ToList();
            return View(_dirs);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
