namespace EEMS.DataAccess.Models
{
    public class DrivingLicenseType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeeDrivingLicense> EmployeeDrivingLicenses { get; set; }
    }
}
