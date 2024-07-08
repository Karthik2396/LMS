using System;
using System.Collections.Generic;

namespace LMS.Model.Models;

public partial class MemberDetail
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime? JoinedDate { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public virtual ICollection<Borrowed> Borroweds { get; } = new List<Borrowed>();

    public virtual ICollection<Fine> Fines { get; } = new List<Fine>();
}
