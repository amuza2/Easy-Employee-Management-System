namespace EEMS.DataAccess.Models;

public class OpenedJob
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }

    public virtual ICollection<Condidate> Condidates { get; set; } = new List<Condidate>();
}
