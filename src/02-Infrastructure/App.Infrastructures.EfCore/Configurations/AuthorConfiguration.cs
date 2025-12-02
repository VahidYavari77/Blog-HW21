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
            //builder.HasData(
          //new Author
          //{
          //    Id = 1,
          //    FirstName = "Vahid",
          //    LastName = "Yavari",
          //    Email = "vahid@example.com",
          //    UserName = "vahid123",
          //    Password = "123"
          //},
          //new Author
          //{
          //    Id = 2,
          //    FirstName = "Ali",
          //    LastName = "Moradi",
          //    Email = "ali.moradi@example.com",
          //    UserName = "ali_mr",
          //    Password = "Ali2024!"
          //},
          //new Author
          //{
          //    Id = 3,
          //    FirstName = "Sara",
          //    LastName = "Ahmadi",
          //    Email = "sara.ahmadi@example.com",
          //    UserName = "sara90",
          //    Password = "Sara#9090"
          //},
          //new Author
          //{
          //    Id = 4,
          //    FirstName = "Reza",
          //    LastName = "Karimi",
          //    Email = "reza.karimi@example.com",
          //    UserName = "reza_kr",
          //    Password = "Reza*2025"
          //}
      //);


        }
    }
}

