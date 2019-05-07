using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Domain.Base;

namespace Persistance.Repository
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Guid Add(TEntity stock);
        void Remove(Guid entity);
        void Update(TEntity stock);
        IEnumerable<TEntity> GetAll();
        TEntity Get(Guid id);
    }
}
