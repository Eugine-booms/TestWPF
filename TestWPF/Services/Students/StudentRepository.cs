using TestWPFApp.Model.Decant;
using TestWPFApp.Services.Base;

namespace TestWPFApp.Services.Students
{
    internal class StudentRepository : RepositoryInMemory<Student>
    {
        protected override void Update(Student source, Student distanation)
        {
            distanation.Name = source.Name;
            distanation.Surname = source.Surname;
            distanation.Patronumic = source.Patronumic;
            distanation.Birthday = source.Birthday;
            distanation.Rating = source.Rating;


        }
    }
}
