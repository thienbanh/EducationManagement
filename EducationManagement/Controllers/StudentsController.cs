using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EducationManagement.Entities;
using EducationManagement.Repository;
using DataTables.AspNet.AspNetCore;
using DataTables.AspNet.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using EducationManagement.Models;
using EducationManagement.Helper;
using Microsoft.AspNetCore.Authorization;

namespace EducationManagement.Controllers
{
    [Authorize(Roles = "Assistant")]
    public class StudentsController : Controller
    {
        private readonly EducationManagementContext _context;
        private IHostingEnvironment _hostingEnvironment; // we will create the “xlsx” file in the wwwroot folder. To get wwwroot folder path, we need to inject IHostingEnvironment dependency in the constructor. 
        public StudentsController(EducationManagementContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Students
        
        public async Task<IActionResult> Index()
        {
            var educationManagementContext = _context.Students.Include(s => s.Classes);
            return View(await educationManagementContext.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Classes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            ViewData["ClassesId"] = new SelectList(_context.Classes, "Id", "Name");
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,StudentId,Dob,Status,Gender,ClassesId,CreateDate,UpdateDate")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassesId"] = new SelectList(_context.Classes, "Id", "Id", students.ClassesId);
            return View(students);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            ViewData["ClassesId"] = new SelectList(_context.Classes, "Id", "Id", students.ClassesId);
            return View(students);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,StudentId,Dob,Status,Gender,ClassesId,CreateDate,UpdateDate")] Students students)
        {
            if (id != students.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.Id))
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
            ViewData["ClassesId"] = new SelectList(_context.Classes, "Id", "Id", students.ClassesId);
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .Include(s => s.Classes)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.Students.FindAsync(id);
            _context.Students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentsExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
        public DataTablesJsonResult GetListStudents(IDataTablesRequest request, string name)
        {

            var total = _context.Students.Count();
            var filter = 0;
            if (!string.IsNullOrWhiteSpace(name))
            {
                //phan trang tai dong request.Start va lay so luong tai request.Length
                filter = _context.Students.Where(x => x.Name.Contains(name)).Count();
                var dataPage = _context.Students.Where(x => x.Name.Contains(name))
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.StudentId,
                        NameGrade = s.Classes.Grades.Name,
                        NameClass = s.Classes.Name,
                        Dob = s.Dob.ToShortDateString(),
                        Gender = s.Gender.ToString(),
                        CreateDate = s.CreateDate.ToShortDateString(),
                        UpdateDate = s.UpdateDate.ToShortDateString(),
                    }).ToList();
                var response = DataTablesResponse.Create(request, total, filter, dataPage);
                return new DataTablesJsonResult(response, true);
            }
            else
            {
                filter = total;
                var dataPage = _context.Students.Include(s => s.Classes).ThenInclude(y => y.Grades)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        s.StudentId,
                        NameGrade = s.Classes.Grades.Name,
                        NameClass = s.Classes.Name,
                        Dob = s.Dob.ToShortDateString(),
                        Gender = s.Gender.ToString(),
                        CreateDate = s.CreateDate.ToShortDateString(),
                        UpdateDate = s.UpdateDate.ToShortDateString(),
                    }).ToList();
                var response = DataTablesResponse.Create(request, total, filter, dataPage);
                return new DataTablesJsonResult(response, true);
            }
        }
        public ActionResult OnPostImport()
        {
            IFormFile file = Request.Form.Files[0];
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName); // tạo thư mục từ wwwroot/upload
            if (!Directory.Exists(newPath))
            {
                Directory.CreateDirectory(newPath);
            }
            if (file.Length > 0)   // có file
            {
                string sFileExtension = Path.GetExtension(file.FileName).ToLower(); // get tên file
                string fullPath = Path.Combine(newPath, file.FileName);
                using (var stream = new FileStream(fullPath, FileMode.Create)) // .Create: tạo file 
                {
                    file.CopyTo(stream);
                    stream.Position = 0;
                    if (sFileExtension == ".xls")
                    {
                        HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    }
                    else
                    {
                        XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    }
                }
            }
            return Json(new { isSuccess = true, fileName = file.FileName });
        }
        public DataTablesJsonResult OpenFileAndExcelPaging(IDataTablesRequest request, string fileName)
        {
            string folderName = "Upload";
            string webRootPath = _hostingEnvironment.WebRootPath;
            string newPath = Path.Combine(webRootPath, folderName);

            string sFileExtension = Path.GetExtension(fileName).ToLower();
            ISheet sheet; // tạo sheet
            string fullPath = Path.Combine(newPath, fileName);
            using (var stream = new FileStream(fullPath, FileMode.Open)) //open file từ wwwroot-upload
            {
                var startRow = 7; // đọc từ row 8
                var startRowPaging = startRow + request.Start;     // số dòng bằng 7 + request
                stream.Position = 0; 
                if (sFileExtension == ".xls")
                {
                    HSSFWorkbook hssfwb = new HSSFWorkbook(stream); //This will read the Excel 97-2000 formats  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook  
                }
                else
                {
                    XSSFWorkbook hssfwb = new XSSFWorkbook(stream); //This will read 2007 Excel format  
                    sheet = hssfwb.GetSheetAt(0); //get first sheet from workbook   
                }
                IRow headerRow = sheet.GetRow(startRowPaging); //Get Header Row
                int cellCount = headerRow.LastCellNum;
                var data = new List<ImportExcelModel>();
                var length = 0;
                if (sheet.LastRowNum > startRowPaging + request.Length)  // row cuối lớn hơn row+ request
                {
                    length = startRowPaging + request.Length;  // length = đoạn đó
                }
                else
                {
                    length = sheet.LastRowNum;   // length bằng đoạn còn lại
                }
                for (int i = startRowPaging + (sheet.FirstRowNum + 1); i <= length; i++) //Read Excel File từ 8 đến length
                {
                    var rowdata = new ImportExcelModel();
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                    rowdata.STT = row.GetCell(0).ToString();
                    rowdata.StudentId = row.GetCell(1).ToString();
                    rowdata.LastName = row.GetCell(2).ToString();
                    rowdata.FirstName = row.GetCell(3).ToString();
                    rowdata.Dob = row.GetCell(4).ToString();
                    rowdata.ClassName = row.GetCell(5).ToString();
                    rowdata.GradeName = row.GetCell(6).ToString();
                    rowdata.Gender = row.GetCell(7).ToString();

                    data.Add(rowdata);
                }

                var response = DataTablesResponse.Create(request, sheet.LastRowNum - startRow, sheet.LastRowNum - startRow, data); // phân trang từ row cuối trừ starrow = 7
                return new DataTablesJsonResult(response, true);
            }
        }
    }
}
