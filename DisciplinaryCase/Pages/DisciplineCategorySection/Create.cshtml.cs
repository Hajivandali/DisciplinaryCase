using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DisciplinaryCase;
using DisciplinaryCase.Models;

namespace DisciplinaryCase.Pages.DisciplineCategorySection
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
            return Page();
        }

        [BindProperty]
        public DisciplineCategory DisciplineCategory { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DisciplineCategories.Add(DisciplineCategory);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
