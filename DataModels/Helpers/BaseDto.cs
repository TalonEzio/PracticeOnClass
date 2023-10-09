using DataModels.EF;

namespace DataModels.Helpers
{
    public class BaseDto
    {
        private PracticeOnClassDbContext _context;

        public PracticeOnClassDbContext Context
        {
            get => _context ?? (_context = new PracticeOnClassDbContext());
            private set => _context = value;
        }
    }
}
