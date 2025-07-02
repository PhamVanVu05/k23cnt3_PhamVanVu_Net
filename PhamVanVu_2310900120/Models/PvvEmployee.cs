using System;
using System.Collections.Generic;

namespace PhamVanVu_2310900120.Models;

public partial class PvvEmployee
{
    public int PvvEmpId { get; set; }

    public string? PvvEmpName { get; set; }

    public string? PvvEmpLevel { get; set; }

    public DateOnly? PvvEmpStartDate { get; set; }

    public bool? PvvEmpStatus { get; set; }
}
