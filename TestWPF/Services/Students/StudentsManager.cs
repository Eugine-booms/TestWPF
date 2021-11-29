using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Model.Decant;

namespace TestWPFApp.Services.Students
{
 internal   class StudentsManager
    {
        private readonly StudentRepository student;
        private readonly GroupRepository group;
        public IEnumerable<Student> Students => student.GetAll();
        public IEnumerable<Group> Groups => group.GetAll();

        public StudentsManager(StudentRepository student, GroupRepository group)
        {
            this.student = student;
            this.group = group;
        }

    }
}
