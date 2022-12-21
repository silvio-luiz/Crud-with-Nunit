using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TruckDiscovery.Data;
using TruckDiscovery.Models;

namespace TruckDiscovery.Pages.Trucks
{
    public class DeleteModel : PageModel
    {
        private readonly TruckDiscovery.Data.WarehouseContext _context;

        public DeleteModel(TruckDiscovery.Data.WarehouseContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Trucks == null)
            {
                return NotFound();
            }

            var truck = await _context.Trucks.FirstOrDefaultAsync(m => m.ID == id);

            if (truck == null)
            {
                return NotFound();
            }
            else 
            {
                Truck = truck;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Trucks == null)
            {
                return NotFound();
            }
            var truck = await _context.Trucks.FindAsync(id);

            if (truck != null)
            {
                Truck = truck;
                _context.Trucks.Remove(Truck);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
