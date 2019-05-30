using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementProject.Data;
using LibraryManagementProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagementProject.Controllers
{
    public class UserManagerController : Controller
    {
            private readonly ApplicationDbContext _context;
            private readonly UserManager<LibraryUser> _userManager;
            private readonly RoleManager<IdentityRole> _roleManager;

            public UserManagerController(ApplicationDbContext context, UserManager<LibraryUser> userManager, RoleManager<IdentityRole> roleManager)
            {
                _context = context;
                _userManager = userManager;
                _roleManager = roleManager;
            }
            // GET: UserManagement
            public async Task<ActionResult> Index()
            {
                var userList = _context
                    .Users
                    .ToList();

                ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", -1);

                return View(userList);
            }

            // GET: UserManagement/Details/5
            public async Task<ActionResult> MakeAdmin(string id)
            {
                if (!(await _roleManager.RoleExistsAsync("admin")))
                {
                    await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                }

                var user = await _userManager.FindByIdAsync(id);
                await _userManager.AddToRoleAsync(user, "admin");

                _context.Users.Update(user);
                _context.SaveChanges();

                return RedirectToAction("index");
            }

            public async Task<ActionResult> RemoveAdmin(string id)
            {

                var user = await _userManager.FindByIdAsync(id);
                await _userManager.RemoveFromRoleAsync(user, "admin");
                return RedirectToAction("index");
            }

        }
}