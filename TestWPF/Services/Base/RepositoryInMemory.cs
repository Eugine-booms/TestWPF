using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Model.Interfaces;
using TestWPFApp.Services.Interfaces;

namespace TestWPFApp.Services.Base
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

        public bool Remove(T item) => _items.Remove(item);
        

        public void Update(int id, T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), id, "Индекс не может быть меньше 1");

            var db_item = ((IRepository<T>)this).Get(id);
            if (db_item is null) throw new InvalidOperationException("Редактируемый элемент не найден в репозитарии");
            Update(item, db_item);

        }
        protected abstract void Update(T source, T distanation);
    }
}
