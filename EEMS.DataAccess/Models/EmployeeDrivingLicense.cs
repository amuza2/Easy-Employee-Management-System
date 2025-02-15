namespace EEMS.DataAccess.Models
{
    public class EmployeeDrivingLicense
    {
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        public int DrivingLicenseTypeId { get; set; }
        public DrivingLicenseType DrivingLicenseType { get; set; }
    }
}
