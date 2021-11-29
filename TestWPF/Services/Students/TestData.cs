using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestWPFApp.Model.Decant;

namespace TestWPFApp.Services.Students
{
   internal class TestData

    {
        public static Group [] Groups { get; } = Enumerable
            .Range(1, 10)
            .Select(i => new Group { Name = $"Группа {i}" , Students= new List<Student>() })
            .ToArray();
        public static Student[] Students { get; } = CreateStudents(Groups);

        private static Student [] CreateStudents(IEnumerable<Group> groups)
        {
            var rnd = new Random();
            var index = 1;
            //var student = new List<Student>(100);
            foreach (var group in groups)
            {
                for (int i = 0; i < 10; i++)
                {

                    group.Students.Add(new Student
                    {
                        Name = $"Имя {index}",
                        Surname = $"Фамилия {index}",
                        Patronumic = $"Отчество {index}",
                        Birthday = DateTime.Now.Subtract(TimeSpan.FromDays(300 * rnd.Next(19, 30))),
                        Description = $"Описание {index++}",
                        Rating = rnd.Next(0, 100)

                    }) ;
                }
            }
            var student = groups.SelectMany(g => g.Students).ToArray();
            return student;
        }
    }
}
