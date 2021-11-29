using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Model.Interfaces;
using TestWPFApp.Services.Interfaces;

namespace TestWPFApp.Services.Новая_папка
{
    abstract class RepositoryInMemory<T> : IRepository<T> where T : IEntity
    {
        private List<T> _items = new List<T>();
        private int _lastId = 1;
        public void Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            if (_items.Contains(item)) return;
            item.Id = ++_lastId;
            _items.Add(item);
        }
        protected RepositoryInMemory() { }
        protected RepositoryInMemory(IEnumerable<T> items)
        {

            foreach (var item in items)
            {
                Add(item);
            }
        }

        public IEnumerable<T> GetAll() => _items;

        public void Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
