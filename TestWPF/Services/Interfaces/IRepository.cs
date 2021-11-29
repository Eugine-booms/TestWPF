using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWPFApp.Model.Interfaces;

namespace TestWPFApp.Services.Interfaces
{
    interface IRepository<T> where T : IEntity
    {
        void Add(T item);
        bool Remove(T item);
        void Update(int id, T item);
        T Get(int id) => GetAll().FirstOrDefault(item => item.Id == id);
        IEnumerable<T> GetAll();

        
    }
}
