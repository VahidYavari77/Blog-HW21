using App.Domain.Core.AuthorAgg.Entities;
using App.Domain.Core.CategoryAgg.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructures.EfCore.Configurations
{
 public   class AuthorConfiguration:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors").HasKey(p => p.Id);

            builder.HasMany(a => a.Posts).WithOne(p => p.Author).HasForeignKey(p => p.AuthorId);
            builder.HasMany(a => a.Categories).WithOne(c => c.Author).HasForeignKey(c => c.AuthorId);


        }
    }
}

