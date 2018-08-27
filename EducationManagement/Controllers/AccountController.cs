using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using EducationManagement.Models;
using EducationManagement.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EducationManagement.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly EducationManagementContext _context;

        public AccountController(
                            UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager,
                            RoleManager<ApplicationRole> roleManager,
                            EducationManagementContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
        }

        #region Login
        //Login Page
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Grades");
            }
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                //Check user email or password is valid or not
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (returnUrl != null)
                    {
                        var user = _context.Users.Where(a => a.Email == model.Email).Include(m => m.Roles).FirstOrDefault();
                        if (user !=null)
                        {
                            return RedirectToLocal(user.Roles.FirstOrDefault().Role.DefaultPage);
                        }
                        else
                        {
                            await _signInManager.SignOutAsync();
                            return RedirectToAction("Login", "Account");
                        }

                    }
                    else
                    {
                        return RedirectToAction("Index", "Grades");
                    }
                }
                if (result.IsLockedOut)
                {
                    return RedirectToAction("Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(model);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
        #endregion

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    OtherEmail = model.OtherEmail,
                    Status = model.Status,
                    Name = model.Name,
                    Phone1 = model.Phone1,
                    Phone2 = model.Phone2,
                    StaffId = model.StaffId
                };
                //Create User
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //Check role is exist
                    // any có tồn tại gì đó hay không trả về true false bool
                    bool x = _context.Roles.Any(r => r.Name == model.Role);
                    if (!x)
                    {
                        // first we create Admin role   
                        var role = new ApplicationRole();
                        role.Name = model.Role;
                        switch (model.Role)
                        {
                            case "Admin":
                                role.DefaultPage = "/Account/Index";
                                break;
                            case "Assistant":
                                role.DefaultPage = "/Grades/Index";
                                break;
                        }
                        //Create new role
                        await _roleManager.CreateAsync(role);
                    }
                    //Add user to specified role
                    await _userManager.AddToRoleAsync(user, model.Role);
                    //Login
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        #endregion
        [AllowAnonymous]
        public ActionResult Index(string returnUrl = null)
        {
            // get role form roles
            var user = _context.Set<ApplicationUser>()
                .Include(u => u.Roles)
                .ThenInclude(r => r.Role).ToList();
            ViewData["ReturnUrl"] = returnUrl;
            return View(user);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await _context.Users
                .FirstOrDefaultAsync(m => m.Id == id);
            if (account == null)
            {
                return NotFound();
            }

            return View(account);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var account = await _context.Users.FindAsync(id);
            _context.Users.Remove(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }


}