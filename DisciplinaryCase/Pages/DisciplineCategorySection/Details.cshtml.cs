using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.DisciplineCategorySection
{
    public class DetailsModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public DetailsModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        public DisciplineCategory DisciplineCategory { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DisciplineCategories == null)
            {
                return NotFound();
            }

            var disciplinecategory = await _context.DisciplineCategories.FirstOrDefaultAsync(m => m.ID == id);
            if (disciplinecategory == null)
            {
                return NotFound();
            }
            else
            {
                DisciplineCategory = disciplinecategory;
            }
            return Page();
        }
    }
}
