using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.StudentSection
{
    public class CreateModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public CreateModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["ClassroomId"] = new SelectList(_context.Classrooms, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //var isUnique = await _context.Students.AnyAsync(s => s.MeliCode == Student.MeliCode);
            //if (!isUnique)
            //{
            //    return Page();
            //}


            _context.Students.Add(Student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
