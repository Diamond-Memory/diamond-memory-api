using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using diamond.memory.Data; // Ensure this namespace contains the StoreContext class

namespace diamond.memory;

public class StoreContextFactory : IDesignTimeDbContextFactory<StoreContext>
{
    public StoreContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StoreContext>();
        optionsBuilder.UseSqlite("Data Source=../Registrar.sqlite", b => b.MigrationsAssembly("diamond.memory.Api"));
        return new StoreContext(optionsBuilder.Options);
    }
}