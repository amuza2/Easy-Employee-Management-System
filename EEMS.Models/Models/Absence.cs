﻿namespace EEMS.Models.Models;

public class Absence
{
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    public DateTime Date { get; set; }
    public bool HasJustification { get; set; }
    public string? Note { get; set; }
}