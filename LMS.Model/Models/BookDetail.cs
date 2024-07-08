using System;
using System.Collections.Generic;

namespace LMS.Model.Models;

public partial class BookDetail
{
    public int Id { get; set; }

    public string Author { get; set; }

    public int Category { get; set; }

    public DateTime PubYear { get; set; }

    public string Title { get; set; }

    public string BookId { get; set; }

    public virtual ICollection<Borrowed> Borroweds { get; } = new List<Borrowed>();

    public virtual Category CategoryNavigation { get; set; }
}
