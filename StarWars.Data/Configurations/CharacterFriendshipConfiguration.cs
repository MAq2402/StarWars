using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StarWars.Domain.Entities;

namespace StarWars.Data.Configurations
{
    public class CharacterFriendshipConfiguration : IEntityTypeConfiguration<CharacterFriendship>
    {
        public void Configure(EntityTypeBuilder<CharacterFriendship> builder)
        {
            builder.HasKey(cf => cf.Id);
            builder.HasOne(cf => cf.First).WithMany(c => c.FriendshipsWhereIsFirst);
            builder.HasOne(cf => cf.Second).WithMany(c => c.FriendshipsWhereIsSecond);
        }
    }
}
