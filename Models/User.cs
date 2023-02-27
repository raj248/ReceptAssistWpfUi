using System;
using System.Collections.Generic;

namespace UiDesktopApp1.Models;

public partial class User
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Type { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ICollection<ComplaintAllotment> ComplaintAllotments { get; } = new List<ComplaintAllotment>();
}
