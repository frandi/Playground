using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PG.Model;

namespace PG.Api.DtoModels
{
    public abstract class BaseNewDto<TEntity>
        where TEntity : BaseModel, new()
    {
        public virtual TEntity ToEntity()
        {
            return new TEntity();
        }
    }

    public abstract class BaseDto<TEntity> : BaseNewDto<TEntity>
        where TEntity : BaseModel, new()
    {
        public int Id { get; set; }

        public virtual TEntity ToEntity(TEntity originalEntity)
        {
            return originalEntity;
        }

        public virtual void LoadFromEntity(TEntity entity)
        {
            Id = entity.Id;
        }
    }
}