using TruckDiscovery.Models.TruckViewModels;
using TruckDiscovery.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruckDiscovery.Models;

namespace TruckDiscovery.Pages
{
    public class IndexModel : PageModel
    {
        private readonly WarehouseContext _context;

        public IndexModel(WarehouseContext context)
        {
            _context = context;
        }

        public IList<EnrollmentDateGroup> Trucks { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<EnrollmentDateGroup> data =
                from truck in _context.Trucks
                group truck by truck.FabYear into dateGroup
                select new EnrollmentDateGroup()
                {
                    FabYear = dateGroup.Key,
                    TruckCount = dateGroup.Count()
                };

            Trucks = await data.AsNoTracking().ToListAsync();
        }
    }
}