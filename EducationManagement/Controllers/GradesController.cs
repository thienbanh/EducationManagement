using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationManagement.Entities;
using EducationManagement.Repository;
using DataTables.AspNet.Core;
using DataTables.AspNet.AspNetCore;
using Microsoft.AspNetCore.Authorization;

namespace EducationManagement.Controllers
{
    [Authorize(Roles = "Assistant")]
    public class GradesController : Controller
    {
        private readonly EducationManagementContext _context;

        public GradesController(EducationManagementContext context)
        {
            _context = context;
        }

        // GET: Grades
        public IActionResult Index()
        {
            return View(_context.Grades.ToList());
        }

        // GET: Grades/Details/5  {controller}/{action}/{optional parameter}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grades = await _context.Grades
                .FirstOrDefaultAsync(m => m.Id == id);

            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        // GET: Grades/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Grades grades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grades);
        }

        // GET: Grades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grades = await _context.Grades.FindAsync(id);
            if (grades == null)
            {
                return NotFound();
            }
            return View(grades);
        }

        // POST: Grades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Grades grades)
        {
            if (id != grades.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GradesExists(grades.Id))
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
            return View(grades);
        }

        // GET: Grades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grades = await _context.Grades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grades == null)
            {
                return NotFound();
            }

            return View(grades);
        }

        // POST: Grades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grades = await _context.Grades.FindAsync(id);
            _context.Grades.Remove(grades);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GradesExists(int id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }

        public DataTablesJsonResult GetListGrades(IDataTablesRequest request, string name)
        {
            var dataPage = new List<Grades>();
            var total = _context.Grades.Count();
            var filter = 0;
            if (!string.IsNullOrWhiteSpace(name))
            {
                //phan trang tai dong request.Start va lay so luong tai request.Length
                filter = _context.Grades.Where(x => x.Name.Contains(name)).Count();
                dataPage = _context.Grades.Where(x => x.Name.Contains(name)).Skip(request.Start).Take(request.Length).ToList();
            }
            else
            {
                filter = total;
                dataPage = _context.Grades.Skip(request.Start).Take(request.Length).ToList();
            }
            var response = DataTablesResponse.Create(request, total, filter, dataPage);

            return new DataTablesJsonResult(response, true);
        }


    }
}
