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
    public class IndexModel : PageModel
{
    private readonly WarehouseContext _context;
    public IndexModel(WarehouseContext context)
    {
        _context = context;
    }

    public string NameSort { get; set; }
    public string DateSort { get; set; }
    public string CurrentFilter { get; set; }
    public string CurrentSort { get; set; }

    public IList<Truck> Trucks { get; set; }

    public async Task OnGetAsync(string sortOrder)
    {
        // using System;
        NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        DateSort = sortOrder == "Date" ? "date_desc" : "Date";

        IQueryable<Truck> trucksIQ = from s in _context.Trucks
                                        select s;

        switch (sortOrder)
        {
            case "name_desc":
                trucksIQ = trucksIQ.OrderByDescending(s => s.Model);
                break;
            case "Date":
                trucksIQ = trucksIQ.OrderBy(s => s.FabYear);
                break;
            case "date_desc":
                trucksIQ = trucksIQ.OrderByDescending(s => s.ModelYear);
                break;
            default:
                trucksIQ = trucksIQ.OrderBy(s => s.ID);
                break;
        }

        Trucks = await trucksIQ.AsNoTracking().ToListAsync();
    }
}
}
