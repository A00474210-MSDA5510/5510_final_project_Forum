using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _5510_final_project_Forum.Data;
using _5510_final_project_Forum.Models;
using Newtonsoft.Json;
using _5510_final_project_Forum.Models.ViewModels;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace _5510_final_project_Forum.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //private readonly ISubscriptions _subscriptionServices;
        private static UserManager<ApplicationUser> _userManager;

        public SubscriptionsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            //_subscriptionServices = subscriptionServices;
            _userManager = userManager;
        }

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
              return _context.Subscription != null ? 
                          View(await _context.Subscription.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Subscription'  is null.");
        }

        [HttpPost]
        public async Task<IActionResult> Index(string selectedPlan)
        {
            Subscription subscription = JsonConvert.DeserializeObject<Subscription>(selectedPlan);
            //ViewData["Subscription"]= subscription;
            PaymentViewModel paymentViewModel = new PaymentViewModel();
            paymentViewModel.Subscription = subscription;
            return View("Payment",paymentViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> PaymentResult(PaymentViewModel paymentViewModel)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            user.isSubbed = 1;
            IdentityResult result = await _userManager.UpdateAsync(user);
            return Content("Payment Done!"+paymentViewModel.Payment);
        }

        public IActionResult ValidateCreditCardNo([Bind(Prefix = "CreditCard.CreditCardId")] String CreditCardId, [Bind(Prefix = "CreditCard.Type")] String CreditCardType)
        {
            if (CreditCardType.Equals("MasterCard"))
            {
                if (!Regex.Match(CreditCardId, "^5[1-5]([0-9]{14})$").Success)
                    return Json("Invalid MasterCard Card No");
            }
            else if (CreditCardType.Equals("VISA"))
            {
                if (!Regex.Match(CreditCardId, "^4([0-9]{15})$").Success)
                    return Json("Invalid VISA Card No");
            }
            else if (CreditCardType.Equals("American Express"))
            {
                if (!Regex.Match(CreditCardId, "^3(4|7)([0-9]{13})$").Success)
                    return Json("Invalid American Express Card No");
            }
            return Json(true);
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubscriptionId,Plan,Duration,Cost")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubscriptionId,Plan,Duration,Cost")] Subscription subscription)
        {
            if (id != subscription.SubscriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.SubscriptionId))
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
            return View(subscription);
        }

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Subscription == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscription
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Subscription == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Subscription'  is null.");
            }
            var subscription = await _context.Subscription.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscription.Remove(subscription);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
          return (_context.Subscription?.Any(e => e.SubscriptionId == id)).GetValueOrDefault();
        }
    }
}
