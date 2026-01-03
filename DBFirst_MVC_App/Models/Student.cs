using System;
using System.Collections.Generic;

namespace DBFirst_MVC_App.Models;

public partial class Student
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public string FullName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string? PhoneNumber { get; set; }
}
