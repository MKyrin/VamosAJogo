using System;

namespace VamosAJogo.Core.Model
{
    public class BaseEntity
    {
        public long Id { get; protected set; }
        public bool IsTransient => Id <= 0;

    }
}
