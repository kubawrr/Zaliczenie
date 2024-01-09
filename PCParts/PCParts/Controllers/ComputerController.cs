using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCParts.Models;
using PCParts.Services;

namespace PCParts.Controllers
{
    [Authorize(Roles = "admin")]
    public class ComputerController : Controller
    {
        private readonly IComputerService _computer;
        public ComputerController(IComputerService computer)
        {
            _computer = computer;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View(_computer.FindAll());
        }
        public IActionResult ComputerForm()
        {
            Computer computer = new Computer();
            computer.Organizations = _computer
                    .FindAllOrganizationsForViewModel()
                    .Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Title })
                    .ToList();
            return View(computer);
        }

        [HttpPost]
        public IActionResult Create(Computer Computer)
        {
            if (ModelState.IsValid)
            {
                _computer.Add(Computer);
                return RedirectToAction("Index"); 
            } 
            else
            {
                return View(Computer);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _computer.Delete(id);
            return RedirectToAction("Index");
        }
       
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_computer.Details(id));
        }

        [HttpGet] 
        public IActionResult Edit(int id)
        {
            return View(_computer.Update(id));
        }
        [HttpPost] 
        public IActionResult Edit(Computer computer)
        {
            _computer.Update(computer);
            return RedirectToAction("Index");
        }
        
    }
}
