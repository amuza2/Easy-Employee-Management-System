
using EEMS.UI.ViewModels;

namespace EEMS.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            // Arrange
            ViewEmployeeDetailsViewModel detailsViewModel = new ViewEmployeeDetailsViewModel(new Employee(), new EmployeeManagementService());
            // Act

            // Assert
            Assert.Pass();
        }
    }
}
