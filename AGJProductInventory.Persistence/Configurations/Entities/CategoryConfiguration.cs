using AGJProductInventory.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AGJProductInventory.Persistence.Configurations.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData
            (
                new Category
                {
                    Id = 1,
                    Name = "Rough Stone"
                },
                new Category
                {
                    Id = 2,
                    Name = "Polished Stone"
                },
                new Category
                {
                    Id = 3,
                    Name = "Wire"
                },
                new Category
                {
                    Id = 4,
                    Name = "Chain"
                }
            );
        }
    }
}
