using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TruckDiscovery.Data;
using TruckDiscovery.Models;

namespace TruckDiscovery.Pages.Trucks
{
    public class CreateModel : PageModel
    {
        private readonly TruckDiscovery.Data.WarehouseContext _context;

        public CreateModel(TruckDiscovery.Data.WarehouseContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Truck Truck { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Trucks.Add(Truck);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
