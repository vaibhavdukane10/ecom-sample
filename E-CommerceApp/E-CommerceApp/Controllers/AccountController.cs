using E_CommerceApp.Data;
using E_CommerceApp.Models;
using E_CommerceApp.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace E_CommerceApp.Controllers
{
    public class AccountController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly ApplicationDbContext _context;
         
        public AccountController(ApplicationDbContext context) { 
        
            _context = context;
        }

        //Get
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                if (await _context.Customers.AnyAsync(a => a.Email == model.Email))
                {
                    ModelState.AddModelError("", "Email Already Registerd");
                    return View(model);
                }

                var customer = new Customer
                { 
                    Email = model.Email,
                CustomerName = model.Name,
                Password = model.Password,
                Phone = model.Phone,
                BillingAddress = model.BillingAddress,
                    
                };  
                
                _context.Customers.Add(customer);

                await _context.SaveChangesAsync();

                return RedirectToAction("Login");

            }
            return View(model);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {
              
                var customer = _context.Customers.AsNoTracking().FirstOrDefault(a => a.Email == model.Email && a.Password == model.Password);
           
            if (customer != null)
            {
                    //Create claims for the authenticated user
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier,customer.Id.ToString()),
                        new Claim(ClaimTypes.Name,customer.CustomerName),
                        new Claim(ClaimTypes.NameIdentifier,customer.Email)
                    };
            

                    var claimsIdentity =new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Order");

                }
                ModelState.AddModelError("","Invalid Login attempt");

            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        { 
            //sign out the user 
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //redirect login page after logout
        return RedirectToAction("Login");
        }
    }
}
