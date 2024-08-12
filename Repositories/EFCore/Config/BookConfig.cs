using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                    new Book { Id = 1, Title = "Satranç", Price = 150 },
                    new Book { Id = 2, Title = "Suç ve Ceza", Price = 250 },
                    new Book { Id = 3, Title = "Cadı", Price = 130 },
                    new Book { Id = 4, Title = "Aden", Price = 200 },
                    new Book { Id = 5, Title = "Olasılık", Price = 265 }
                );
        }
    }
}
