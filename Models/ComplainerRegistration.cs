using System;
using System.Collections.Generic;

namespace UiDesktopApp1.Models;

public partial class ComplainerRegistration
{
    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public DateTime? RegistrationDatetime { get; set; }

    public int ComplainerId { get; set; }

    public virtual ICollection<ComplaintRegister> ComplaintRegisters { get; } = new List<ComplaintRegister>();
}
