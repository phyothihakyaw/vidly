using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Vidly.Web.Data;
using Vidly.Web.Models;
using Vidly.Web.ViewModels;

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

        // GET : Customers/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers
                .Include(c => c.MembershipType)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (customer == null)
                return NotFound();
            

            return View(customer);
        }

        // GET : Customers/New
        public async Task<IActionResult> New()
        {
            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            var viewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = MembershipType.ConvertToSelectListItem(membershipTypes)
            };

            return View("CustomerForm", viewModel);
        }

        // POST : Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("Id,Name,Birthdate,IsSubscribedToNewsletter,MembershipTypeId")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        // GET : Customers/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var customer = await _context.Customers.SingleAsync(c => c.Id == id);
            if (customer == null)
                return NotFound();

            var membershipTypes = await _context.MembershipTypes.ToListAsync();
            var viewModel = new CustomerViewModel
            {
                Customer = customer,
                MembershipTypes = MembershipType.ConvertToSelectListItem(membershipTypes)
            };

            return View("CustomerForm", viewModel);
        }

        //POST : Customers/Save/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(int id, [Bind("Id,Name,BirthDate,IsSubscribedToNewsletter,MembershipTypeId")] Customer customer)
        {
            if (id != customer.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {

                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(customer);
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}
