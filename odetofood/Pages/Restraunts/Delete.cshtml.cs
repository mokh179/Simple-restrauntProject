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
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData RestaurantData;
        public Resturaunts Resturaunt { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.RestaurantData = restaurantData;
        }

      

        public IActionResult OnGet(int id)
        {
            Resturaunt = RestaurantData.GetDatabyID(id);
            if (Resturaunt == null) 
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }
        public IActionResult OnPost(int id)
        {
            Resturaunt = RestaurantData.delete(id);
            RestaurantData.commit();
            if (Resturaunt==null)
            {
                return RedirectToPage("./NotFound ");
            }
            else
            {
                TempData["Message"] = $"{Resturaunt.Name} Deleted";
                return RedirectToPage("./List");
            }
        }
    }
}