/*

Database configuration

use modelbuilder to creator common rules on your models likes keys, foreign keys, index etc.

*/


namespace SharpApi.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
    }
}
