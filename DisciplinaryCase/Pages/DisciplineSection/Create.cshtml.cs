using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DisciplinaryCase.Pages.DisciplineSection
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
            ViewData["DisciplineCategoryId"] = new SelectList(_context.DisciplineCategories, "ID", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName");
            return Page();
        }

        [BindProperty]
        public Discipline Discipline { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            _context.Disciplines.Add(Discipline);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
