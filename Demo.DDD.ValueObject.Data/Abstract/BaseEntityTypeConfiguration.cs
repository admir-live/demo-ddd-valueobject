using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Omni.SharedKernel.Domain;

namespace Demo.DDD.ValueObject.Data.Abstract
{
    public abstract class BaseEntityTypeConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(keyExpression: c => c.Id);

            builder
                .Property(propertyExpression: p => p.CreatedAt)
                .IsRequired();

            builder
                .Property(propertyExpression: p => p.ModifiedAt)
                .IsRequired();
        }
    }
}