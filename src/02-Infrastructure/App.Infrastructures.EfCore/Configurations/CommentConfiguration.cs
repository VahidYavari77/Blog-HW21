using App.Domain.Core.CategoryAgg.Entities;
using App.Domain.Core.CommentAgg.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {


        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments").HasKey(c => c.Id);
            builder.HasOne(c => c.Post).WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId);
            builder.Property(c => c.CommentText)
                 .IsRequired()
                 .HasMaxLength(2000);
                 

        }
    }
}
