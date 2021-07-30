using System;
using Demo.DDD.ValueObject.Data.Abstract;
using Demo.DDD.ValueObject.Data.Model;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Sample.Mutable.Process.Infrastructure.Database.Configuration
{
    public class UserEntityTypeConfiguration : BaseEntityTypeConfiguration<User, Guid>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder: builder);

            builder
                .Property(propertyExpression: p => p.FirstName)
                .IsRequired()
                .HasMaxLength(maxLength: 255)
                .IsUnicode();

            builder
                .Property(propertyExpression: p => p.LastName)
                .IsRequired()
                .HasMaxLength(maxLength: 255)
                .IsUnicode();

            builder
                .Property(propertyExpression: j => j.UserName)
                .HasConversion(converter: new ValueConverter<UserName, string>(
                    convertToProviderExpression: v => v.Value,
                    convertFromProviderExpression: v => UserName.Parse(v)))
                .IsUnicode();
        }
    }
}