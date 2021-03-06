﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Dal.Interface.DTO;
namespace Dal.Interface.Repository
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);
        TEntity GetByName(string Name);
        void Create(TEntity e);
        void Delete(TEntity e);
        int GetId(TEntity e);
    }
}
