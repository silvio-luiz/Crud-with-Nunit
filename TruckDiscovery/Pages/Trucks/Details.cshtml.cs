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
    public class DetailsModel : PageModel
    {
        private readonly TruckDiscovery.Data.WarehouseContext _context;

        public DetailsModel(TruckDiscovery.Data.WarehouseContext context)
        {
            _context = context;
        }

      public Truck Truck { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Truck = await _context.Trucks
                .Include(s => s.Enrollments)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Truck == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
