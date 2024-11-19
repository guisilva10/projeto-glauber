using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseNpgsql("Host=ep-proud-darkness-a58hi7c4.us-east-2.aws.neon.tech;Port=5432;Username=neondb_owner;Password=17pQHvDezcRa;Database=neondb;SSL Mode=Require");

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
