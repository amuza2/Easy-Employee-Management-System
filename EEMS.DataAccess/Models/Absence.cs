namespace EEMS.DataAccess.Models
{
    public class Absence
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public DateTime Date { get; set; }
        public int Days { get; set; }
        public string Note { get; set; }

        public int AbsenceTypeId { get; set; }
        public virtual AbsenceType AbsenceType { get; set; }
    }
}
