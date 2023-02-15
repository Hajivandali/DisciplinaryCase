using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.DisciplineSection
{
    public class DetailsModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public DetailsModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

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
    }
}
