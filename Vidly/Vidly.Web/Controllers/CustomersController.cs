using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Vidly.Web.Data;

namespace Vidly.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET : Customers
        public async Task<IActionResult> Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType);
            return View(await customers.ToListAsync());
        }
    }
}
