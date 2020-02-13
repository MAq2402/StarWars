using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Domain.Entities;

namespace StarWars.Data.Configurations
{
    public class CharacterConfiguration : IEntityTypeConfiguration<Character>
    {
        public void Configure(EntityTypeBuilder<Character> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Episodes)
                .HasConversion(x => string.Join(',', x),
                    y => y.Split(',', StringSplitOptions.None).ToList());

            builder.Ignore(c => c.Friends);
        }
    }
}