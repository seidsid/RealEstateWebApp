using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using NurRealEstateWebApp.Entities;
using NurRealEstateWebApp.Models;
using NurRealEstateWebApp.Repository;
using NurRealEstateWebApp.Service;

namespace NurRealEstateWebApp.Controllers
{
    public class PropertyController : Controller
    {
        private readonly ILogger<PropertyController> _logger;
        private readonly NurDbContext nurDbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IPropertyService ps;
        private readonly IPropertyRepository pr;

        public PropertyController(ILogger<PropertyController> logger, NurDbContext _nurDbContext,IWebHostEnvironment hostingEnvironment, IPropertyService ps, IPropertyRepository pr)
        {
            _logger = logger;
            this.nurDbContext = _nurDbContext;
            this.webHostEnvironment = hostingEnvironment;
            this.ps = ps;
            this.pr = pr;   
        }


        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddProperty()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProperty(PropertyViewModel pvm)
        {
            pvm.Agent_id = Guid.Parse("c3a1713f-1668-4980-6c68-08dc18aa388c");
            pvm.User_id = Guid.Parse("014315fb-fe1a-4e4d-8a5e-08dc18448d6b");

            Console.WriteLine(pvm);


            await ps.CreateProperty(pvm);

            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DisplayProperty()
        {
            List<Property> properties = await pr.GetAllProperties();

            // Create an instance of PropertyListViewModel and set its properties
            PropertyListViewModel model = new PropertyListViewModel
            {
                Model = properties,
                Filter = new FilterViewModel() // You can set the filter information here if needed
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DisplayPropertyDetail(Guid id)
        {
            Property property = await pr.GetPropertyById(id);
            return View(property);
        }

        [HttpPost]
        public async Task<IActionResult> DisplayFilters(FilterViewModel fvm)
        {
            List<Property> filteredProperties = await ps.GetFilter(fvm);

            // Create an instance of PropertyListViewModel and set its properties
            PropertyListViewModel model = new PropertyListViewModel
            {
                Model = filteredProperties,
                Filter = fvm
            };

            return View("DisplayProperty", model);
        }




    }
}
