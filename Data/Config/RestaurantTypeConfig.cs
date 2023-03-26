using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Config
{
    public class RestaurantTypeConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> builder)
        {
            // It is not necessary to use fluent api approach when already using convention based rs in the entities models
            builder.HasOne(r => r.Cuisine)
                   .WithMany();
                   
        }
    }
}
