using System;
using System.Collections.Generic;
using System.Text;

namespace VamosAJogo.Infrastructure.Repository
{
    public interface IRepository<T>
    {
        T Get(object id);

        bool Insert(T item);

        bool Update(T item);

        bool Delete(T item);
    }
}
