using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ASPCRUD.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new CodeContext(
                serviceProvider.GetRequiredService<DbContextOptions<CodeContext>>());
            context.Database.EnsureCreated();
        }
    }
}