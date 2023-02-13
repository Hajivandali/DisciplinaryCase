using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DisciplinaryCase;
using DisciplinaryCase.Models;

namespace DisciplinaryCase.Pages.DisciplineCategorySection
{
    public class EditModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public EditModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DisciplineCategory DisciplineCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null || _context.DisciplineCategories == null)
            {
                return NotFound();
            }

            var disciplinecategory =  await _context.DisciplineCategories.FirstOrDefaultAsync(m => m.ID == id);
            if (disciplinecategory == null)
            {
                return NotFound();
            }
            DisciplineCategory = disciplinecategory;
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

            _context.Attach(DisciplineCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineCategoryExists(DisciplineCategory.ID))
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

        private bool DisciplineCategoryExists(long id)
        {
          return _context.DisciplineCategories.Any(e => e.ID == id);
        }
    }
}
