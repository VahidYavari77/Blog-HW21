using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.PostAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts").HasKey(p => p.Id);
            builder.HasMany(p => p.Comments).WithOne(c => c.Post)
                .HasForeignKey(p => p.PostId);
            builder.HasOne(p => p.Author).WithMany(a => a.Posts)
                .HasForeignKey(p => p.AuthorId);
            builder.HasOne(p => p.Category).WithMany(c => c.Posts)
               .HasForeignKey(p => p.CategoryId);
            builder.Property(p => p.Text)
                 .IsRequired()
                 .HasMaxLength(4000)
                 .HasColumnType("nvarchar(4000)");
        }
    }
}
