using System;
using System.Collections.Generic;

namespace LMS.Model.Models;

public partial class Category
{
    public int Id { get; set; }

    public string CatName { get; set; }

    public virtual ICollection<BookDetail> BookDetails { get; } = new List<BookDetail>();
}
