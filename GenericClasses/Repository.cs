using System;
using System.Collections.Generic;
using System.Text;

namespace GenericClasses
{
    // For mandatory ID

    internal interface IEntity
    {
        int Id { get; }
    }
    // Implementing IEntity
    internal class Repository<T> where T : IEntity
    {
        
        private List<T> _entities = new List<T>();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }
    }
}
