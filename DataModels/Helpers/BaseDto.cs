using DataModels.EF;

namespace DataModels.Helpers
{
    public class BaseDto
    {
        private PracticeOnClassDbContext _context;

        public PracticeOnClassDbContext Context => _context ?? (_context = new PracticeOnClassDbContext());
    }
}
