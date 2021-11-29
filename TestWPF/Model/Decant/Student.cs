using System;
using System.Text;
using TestWPFApp.Model.Interfaces;

namespace TestWPFApp.Model.Decant
{
    internal    class Student             : IEntity

    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronumic { get; set; }
        public DateTime Birthday { get; set; }
        public double Rating { get; set; }
        public string Description { get; set; }
        public int Id { get  ; set  ; }
    }
}
