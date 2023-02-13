using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.ClassroomSection
{
    public class IndexModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public IndexModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        public IList<Classroom> Classroom { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Classrooms != null)
            {
                Classroom = await _context.Classrooms.ToListAsync();
            }
        }
    }
}
