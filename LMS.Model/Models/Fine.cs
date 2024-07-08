using System;
using System.Collections.Generic;

namespace LMS.Model.Models;

public partial class Fine
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public DateTime FineDate { get; set; }

    public int? FineAmount { get; set; }

    public virtual MemberDetail Member { get; set; }
}
