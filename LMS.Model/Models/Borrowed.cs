using System;
using System.Collections.Generic;

namespace LMS.Model.Models;

public partial class Borrowed
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public DateTime BorrowedDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int? FineAmount { get; set; }

    public virtual BookDetail Book { get; set; }

    public virtual MemberDetail Member { get; set; }
}
