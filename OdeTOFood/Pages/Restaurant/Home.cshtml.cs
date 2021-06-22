using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeTOFood.Core;
using OdeTOFood.Data;

namespace OdeTOFood.Pages.Restaurant
{
    public class HomeModel : PageModel
    {
        public readonly IConfiguration _config;
        public readonly IResturantData _resturantData;
        public string Message { get; set; }
        [BindProperty(SupportsGet = true)]
        public string rName { get; set; }
        public IEnumerable<Restuarant> Restuarants { get; set; }
        public HomeModel(IConfiguration config, IResturantData resturantData)
        {
            this._config = config;
            this._resturantData = resturantData;
        }

        public void OnGet()
        {
            Message = "Hello World.";
            Message = _config["Message"];
            Restuarants = _resturantData.GetRestuarants();
        }
    }
}