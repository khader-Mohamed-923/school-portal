using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Grades.Data;
using SchoolPortal.Grades.Models;
using SchoolPortal.Grades.Services;

namespace SchoolPortal.Grades.Controllers;

public class GradesController : Controller
{
    private readonly GradeDbContext _dbContext;
    private readonly StudentsClient _studentsClient;    

    public GradesController(GradeDbContext dbContext, StudentsClient studentsClient)
    {
        _dbContext = dbContext;
        _studentsClient = studentsClient;
    }


    public async Task<IActionResult> Index()
    {

        var grades = await _dbContext.Grades
                                     .AsNoTracking()
                                     .ToListAsync();
        return View(grades);
    }


    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || id < 0)
        {
            return BadRequest();
        }
        var grade = await _dbContext.Grades
                                    .FindAsync(id);

        if (grade == null)
        {
            return NotFound();
        }

        return View(grade);

    }


    public IActionResult Create()
    {
        return View();
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Grade grade)
    {
        if(!ModelState.IsValid)
        {
            return View(grade);
        }
        var studentExists = await _studentsClient.IsStudentExistsAsync(grade.StudentId);
        if (!studentExists)
        {
            ModelState.AddModelError("StudentId", "The selected student does not exist.");
      
            return View(grade);
        }
     
            _dbContext.Grades.Add(grade);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id < 0)
        {
            return BadRequest();
        }
        var grade = await _dbContext.Grades
                                       .FindAsync(id);
        if (grade == null)
        {
            return NotFound();
        }
        return View(grade);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Grade grade)
    {
        if (id != grade.Id)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(grade);
        }

        try
        {
            _dbContext.Grades.Update(grade);
            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {

            if (!GradeExists(id))
            {
                return NotFound();
            }

            throw;
        }

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id < 0)
        {
            return BadRequest();
        }
        var grade = await _dbContext.Grades
                                    .FindAsync(id);
        if (grade == null)
        {
            return NotFound();
        }
        return View(grade);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]

    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var grade = await _dbContext.Grades.FindAsync(id);
        if (grade == null)
        {
            return NotFound();
        }
        _dbContext.Grades.Remove(grade);
        await _dbContext.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool GradeExists(int id)
    {
        return _dbContext.Grades.Any(e => e.Id == id);
    }

}







