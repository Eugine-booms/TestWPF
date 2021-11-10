using System.Collections.Generic;

namespace TestWPFApp.Model.Decant
{
    internal class Group
    {
        public string Name { get; set; }
        public IList<Student> Students { get; set; }
    }
}
