using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.DisciplineSection
{
    public class EditModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public EditModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discipline Discipline { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }

            var discipline = await _context.Disciplines.FirstOrDefaultAsync(m => m.Id == id);
            if (discipline == null)
            {
                return NotFound();
            }
            Discipline = discipline;
            ViewData["DisciplineCategoryId"] = new SelectList(_context.DisciplineCategories, "ID", "Name");
            ViewData["StudentId"] = new SelectList(_context.Students, "Id", "FirstName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Discipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(Discipline.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DisciplineExists(long id)
        {
            return _context.Disciplines.Any(e => e.Id == id);
        }
    }
}
