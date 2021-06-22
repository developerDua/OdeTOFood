using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeTOFood.Core;
using OdeTOFood.Data;

namespace OdeTOFood.Pages.Restaurant
{
    public class EditModel : PageModel
    {
        [BindProperty] public Restuarant Restaurant { get; set; }
        public IResturantData ResturantData { get; set; }
        public IEnumerable<SelectListItem> CusineItems { get; set; }

        public EditModel(IResturantData resturantData, IHtmlHelper htmlHelper)
        {
            ResturantData = resturantData;
            CusineItems = htmlHelper.GetEnumSelectList<CusineType>();
        }

        public IActionResult OnGet(int? restaurantId)
        {
            Restaurant = restaurantId.HasValue
                ? ResturantData.GetRestuarantById(Convert.ToInt32(restaurantId))
                : new Restuarant();
            if (Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var restuarant = Restaurant.Id <= 0 ? ResturantData.Add(Restaurant) : ResturantData.Update(Restaurant);

            if (restuarant != null)
            {
                ResturantData.Commit();
                return RedirectToPage("./Home");
            }

            return Page();
        }
    }
}