using Microsoft.EntityFrameworkCore;

namespace ASPCRUD.Models
{
    public class CodeContext : DbContext
    {
        public CodeContext (DbContextOptions<CodeContext> options)
            : base(options)
        {
        }

        public DbSet<ASPCRUD.Models.Code> Code { get; set; }
    }
}