using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DisciplinaryCase;
using DisciplinaryCase.Models;

namespace DisciplinaryCase.Pages.DisciplineCategorySection
{
    public class DeleteModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public DeleteModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null || _context.DisciplineCategories == null)
            {
                return NotFound();
            }
            var disciplinecategory = await _context.DisciplineCategories.FindAsync(id);

            if (disciplinecategory != null)
            {
                DisciplineCategory = disciplinecategory;
                _context.DisciplineCategories.Remove(DisciplineCategory);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
