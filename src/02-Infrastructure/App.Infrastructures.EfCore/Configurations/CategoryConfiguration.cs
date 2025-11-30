using App.Domain.Core.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories").HasKey(p => p.Id);
            builder.HasMany(c => c.Posts).WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);
            builder.HasOne(c => c.Author).WithMany(a => a.Categories)
                .HasForeignKey(c => c.AuthorId);
        }
    }
}
