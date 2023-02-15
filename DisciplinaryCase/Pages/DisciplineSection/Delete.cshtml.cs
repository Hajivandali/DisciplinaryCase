using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.DisciplineSection
{
    public class DeleteModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public DeleteModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Discipline Discipline { get; set; }

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
            else
            {
                Discipline = discipline;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.Disciplines == null)
            {
                return NotFound();
            }
            var discipline = await _context.Disciplines.FindAsync(id);

            if (discipline != null)
            {
                Discipline = discipline;
                _context.Disciplines.Remove(Discipline);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
