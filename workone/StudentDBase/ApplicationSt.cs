using Microsoft.EntityFrameworkCore;
using workone.Models;

namespace workone.StudentDBase;

public class ApplicationSt :DbContext
{
    public ApplicationSt (DbContextOptions<ApplicationSt> options) : base(options)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(Student).Assembly);
    }

}
