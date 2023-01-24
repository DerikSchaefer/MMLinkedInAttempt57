using Microsoft.EntityFrameworkCore;

namespace MMLinkedInAttempt57.Data
{
    public class MMLinkedInAttempt57Context : DbContext
    {
        public MMLinkedInAttempt57Context(DbContextOptions<MMLinkedInAttempt57Context> options)
            : base(options)
        {
        }

        public DbSet<MMLinkedInAttempt57.Models.GuessTime> GuessTimes { get; set; }
    }
}
