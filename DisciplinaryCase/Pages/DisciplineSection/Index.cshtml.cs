using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.DisciplineSection
{
    public class IndexModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public IndexModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        public IList<Discipline> Discipline { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Disciplines != null)
            {
                Discipline = await _context.Disciplines
                .Include(d => d.DisciplineCategory)
                .Include(d => d.Student).ToListAsync();
            }
        }
    }
}
