using System;

namespace Omni.SharedKernel.Domain
{
    public abstract class BaseEntity<TKey> : BaseEntity where TKey : IEquatable<TKey>
    {
        public virtual TKey Id { get; set; }
    }
}