using DisciplinaryCase.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DisciplinaryCase.Pages.StudentSection
{
    public class IndexModel : PageModel
    {
        private readonly DisciplinaryCase.DisciplineContext _context;

        public IndexModel(DisciplinaryCase.DisciplineContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students
                .Include(s => s.Classroom).ToListAsync();
            }
        }
    }
}
