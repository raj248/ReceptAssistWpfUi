using System;
using System.Collections.Generic;

namespace UiDesktopApp1.Models;

public partial class Comment
{
    public string? CommentText { get; set; }

    public int? ComplaintIdFk { get; set; }

    public string? CommenterId { get; set; }

    public DateTime? DateTime { get; set; }

    public int Id { get; set; }

    public virtual User? Commenter { get; set; }

    public virtual ComplaintRegister? ComplaintIdFkNavigation { get; set; }
}
