using System;
using System.Collections.Generic;

namespace UiDesktopApp1.Models;

public partial class ComplaintAllotment
{
    public string? User { get; set; }

    public int? ComplaintIdFk { get; set; }

    public string? Status { get; set; }

    public int Id { get; set; }

    public virtual ComplaintRegister? ComplaintIdFkNavigation { get; set; }

    public virtual User? UserNavigation { get; set; }
}
