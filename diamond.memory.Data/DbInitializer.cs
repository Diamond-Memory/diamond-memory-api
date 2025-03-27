using Microsoft.EntityFrameworkCore;


namespace diamond.memory.Data
{
    public static class DbInitializer
    {
        public static void Initializer(ModelBuilder builder)
        {
            builder.Entity<Item>().HasData(
                new Item("Shirt", "Ohio State shirt", "Nike", 29.99M)
                {
                    Id = 1
                },
                new Item("Shorts", "Ohio State shorts", "Nike", 44.99m)
                {
                    Id= 2
                }
            );
        }
    }
}