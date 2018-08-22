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
                        return RedirectToLocal(returnUrl);
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
                    bool x = await _roleManager.RoleExistsAsync(model.Role);
                    if (!x)
                    {
                        // first we create Admin role   
                        var role = new ApplicationRole();
                        role.Name = model.Role;
                        role.DefaultPage = "/Account/Login";
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
                .ThenInclude(r => r.Role);
            ViewData["ReturnUrl"] = returnUrl;
            return View(_userManager.Users.ToList());
        }

        public DataTablesJsonResult GetListUser(IDataTablesRequest request, string name)
        {

            var total = _userManager.Users.Count();
            var filter = 0;
            if (!string.IsNullOrWhiteSpace(name))
            {
                //phan trang tai dong request.Start va lay so luong tai request.Length
                filter = _userManager.Users.Where(x => x.Name.Contains(name)).Count();
                var dataPage = _userManager.Users.Where(x => x.Name.Contains(name))
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(s => new
                    {
                        s.StaffId,
                        s.Name,
                        s.Email,
                        s.OtherEmail,
                        s.Phone1,
                        s.Phone2,
                        Status = s.Status.ToString(),
                        Role = s.Roles.ToString(),
                        CreateDate = s.CreateDate.ToShortDateString(),
                        UpdateDate = s.UpdateDate.ToShortDateString(),
                    }).ToList();
                var response = DataTablesResponse.Create(request, total, filter, dataPage);
                return new DataTablesJsonResult(response, true);
            }
            else
            {
                filter = total;
                var dataPage = _userManager.Users
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(s => new
                    {
                        s.Id,
                        s.Email,
                        s.Phone1,
                        s.Phone2,
                        Status = s.Status.ToString(),
                        Role = s.Roles.ToString(),
                        CreateDate = s.CreateDate.ToShortDateString(),
                        UpdateDate = s.UpdateDate.ToShortDateString(),
                    }).ToList();
                var response = DataTablesResponse.Create(request, total, filter, dataPage);
                return new DataTablesJsonResult(response, true);
            }
        }
    }


}