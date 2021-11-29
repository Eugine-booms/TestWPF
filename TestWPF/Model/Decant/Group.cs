using System.Collections.Generic;
using TestWPFApp.Model.Interfaces;

namespace TestWPFApp.Model.Decant
{
    internal class Group : IEntity
    {
        public string Name { get; set; }
        public IList<Student> Students { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
