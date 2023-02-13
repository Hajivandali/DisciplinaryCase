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
    public class IndexModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public IndexModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        public IList<DisciplineCategory> DisciplineCategory { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DisciplineCategories != null)
            {
                DisciplineCategory = await _context.DisciplineCategories.ToListAsync();
            }
        }
    }
}
