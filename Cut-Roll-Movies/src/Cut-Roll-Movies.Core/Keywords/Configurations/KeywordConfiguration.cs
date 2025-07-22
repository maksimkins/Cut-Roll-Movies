namespace Cut_Roll_Movies.Core.Keywords.Configurations;

using Cut_Roll_Movies.Core.Keywords.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class KeywordConfiguration : IEntityTypeConfiguration<Keyword>
{
    public void Configure(EntityTypeBuilder<Keyword> builder)
    {
        builder.ToTable("keywords")
            .HasKey(k => k.Id);
    }
}



