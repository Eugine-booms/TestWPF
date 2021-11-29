using TestWPFApp.Model.Decant;
using TestWPFApp.Services.Base;

namespace TestWPFApp.Services.Students
{
    internal class GroupRepository : RepositoryInMemory<Group>
    {
        public GroupRepository() : base (TestData.Groups){ }
        protected override void Update(Group source, Group distanation)
        {
            distanation.Name = source.Name;
            distanation.Description = source.Description;

        }
    }
}
