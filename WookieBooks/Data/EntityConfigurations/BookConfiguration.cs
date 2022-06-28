using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WookieBooks.Api.Entities;

namespace WookieBooks.Api.Data.EntityConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            builder.Property(c => c.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            builder.Property(c => c.Author)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            builder.Property(c => c.CoverImage)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            //builder.HasData(new Book
            //{
            //    Id = 1,
            //    Title = "Data Structure",
            //    Description = "Data Structure by Homer",
            //    Author = "Homer Simpson",
            //    CoverImage = "images/ds.png",
            //    Price = 89.99
            //});
            //builder.HasData(new Book
            //{
            //    Id = 2,
            //    Title = "Design Patterns",
            //    Description = "Design Patterns by Peter",
            //    Author = "Peter Griffin",
            //    CoverImage = "images/dp.png",
            //    Price = 99
            //});

        }
    }
}
