using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolPortal.Students.Data;
using SchoolPortal.Students.Models;

namespace SchoolPortal.Students.Controllers;

public class StudentsController : Controller
{
    private readonly StudentDbContext _dbContext;

    public StudentsController(StudentDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IActionResult> Index()
    {
        var students = await _dbContext.Students
                                       .AsNoTracking()
                                       .ToListAsync();

        return View(students);
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null || id < 0)
        {
            return BadRequest();
        }

        var student = await _dbContext.Students
                                      .FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        var emailExists = await _dbContext.Students
                                          .AsNoTracking()
                                          .AnyAsync(s => s.Email == student.Email);

        if (emailExists)
        {
            ModelState.AddModelError("Email",
                "This email address is already registered to another student");
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }

        student.EnrollmentDate = DateTime.UtcNow;

        _dbContext.Students.Add(student);

        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || id < 0)
        {
            return BadRequest();
        }

        var student = await _dbContext.Students
                                      .FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Student student)
    {
        if (id != student.Id)
        {
            return NotFound();
        }

        var emailExists = await _dbContext.Students
                                          .AsNoTracking()
                                          .AnyAsync(s => s.Email == student.Email && s.Id != id);

        if (emailExists)
        {
            ModelState.AddModelError("Email",
                "This email address is already registered to another student");
        }

        if (!ModelState.IsValid)
        {
            return View(student);
        }

        try
        {
            _dbContext.Students.Update(student);

            _dbContext.Entry(student)
                      .Property(s => s.EnrollmentDate)
                      .IsModified = false;

            await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            var studentExists = await StudentExists(student.Id);

            if (!studentExists)
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

        var student = await _dbContext.Students
                                      .FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return View(student);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var student = await _dbContext.Students
                                             .FindAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        _dbContext.Students.Remove(student);

        await _dbContext.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var students = await _dbContext.Students
                                           .AsNoTracking()
                                           .ToListAsync();

            return Json(students);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "An error occurred while retrieving students.",
                error = ex.Message
            });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetById(int id)
    {
        try
        {
            var student = await _dbContext.Students
                                          .FindAsync(id);

            if (student == null)
            {
                return NotFound(new
                {
                    message = $"Student with ID {id} not found."
                });
            }

            return Json(student);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new
            {
                message = "An error occurred while retrieving student.",
                error = ex.Message
            });
        }
    }

    [HttpGet("api/students/check/{id}")]
    public async Task<IActionResult> CheckStudentExists(int id)
    {
        var exists = await _dbContext.Students.AnyAsync(s => s.Id == id);
        if (!exists)
        {
            return NotFound();
        }
        return Ok();
    }

    private async Task<bool> StudentExists(int id)
    {
        return await _dbContext.Students.AnyAsync(s => s.Id == id);
    }
}