using System.Collections.Generic;

namespace TestWPFApp.Model.Decant
{
    internal class Group
    {
        public string Name { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
