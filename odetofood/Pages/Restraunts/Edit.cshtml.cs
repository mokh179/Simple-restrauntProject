using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using odotofood.core;
using odotofood.data;

namespace odetofood.Pages.Restraunts
{
    public class EditModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        [BindProperty]
        public Resturaunts Restraunt { set; get; }
        public readonly IRestaurantData RestaurantData;
        public IEnumerable<SelectListItem> types { set; get; }
        public IHtmlHelper HtmlHelper { get; }

        public EditModel(IRestaurantData restaurantData,IHtmlHelper htmlHelper)
        {
           this.RestaurantData = restaurantData;
            HtmlHelper = htmlHelper;
        }

        

        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                Restraunt = RestaurantData.GetDatabyID(id.Value);
            }
            else
            {
                Restraunt = new Resturaunts();
            }
           
            types = HtmlHelper.GetEnumSelectList<CuisineType>();
            if (Restraunt == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
         
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                types = HtmlHelper.GetEnumSelectList<CuisineType>();

                return Page();
                      
            }
            if (Restraunt.ID>0)
            {
                RestaurantData.Edit(Restraunt);
            }
            else
            {
                RestaurantData.Add(Restraunt);
            }
            RestaurantData.commit();
            TempData["Message"] = "Restraunt Saved!";
            return RedirectToPage("./Details", new { id = Restraunt.ID });
           
        }
    }
}