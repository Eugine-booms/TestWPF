using System;
using System.Collections.Generic;
using System.Text;
using TestWPFApp.Model.Decant;

namespace TestWPFApp.Services.Students
{
    internal class StudentsManager
    {
        private readonly StudentRepository _student;
        private readonly GroupRepository _group;
        public IEnumerable<Student> Students => _student.GetAll();
        public IEnumerable<Group> Groups => _group.GetAll();

        public StudentsManager(StudentRepository student, GroupRepository group)
        {
            this._student = student;
            this._group = group;
        }
        public void Update(Student student) => _student.Update(student.Id, student);


        internal bool CreateNewStudent(Student student, string groupName)
        {
            if (student is null) throw new ArgumentNullException(nameof(student));
            if (string.IsNullOrWhiteSpace(groupName)) throw new ArgumentException("Некоректное имя группы", nameof(groupName));
            var group = _group.Get(groupName);
            if (group is null)
            {
                group = new Group() { Name = groupName, Students = new List<Student>() };
                _group.Add(group);
            }
            group.Students.Add(student);
            _student.Add(student);
            return true;
        }
    }
}
