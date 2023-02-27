using System;
using System.Collections.Generic;

namespace UiDesktopApp1.Models;

public partial class ComplaintRegister
{
    public string? ComplaintTitle { get; set; }

    public string? ComplaintDetail { get; set; }

    public string? ProofImgFile { get; set; }

    public int? ComplainerIdFk { get; set; }

    public string? IsApprovedByAdmin { get; set; }

    public DateTime? ComplaintDatetime { get; set; }

    public int ComplaintId { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();

    public virtual ComplainerRegistration? ComplainerIdFkNavigation { get; set; }

    public virtual ICollection<ComplaintAllotment> ComplaintAllotments { get; } = new List<ComplaintAllotment>();
}
