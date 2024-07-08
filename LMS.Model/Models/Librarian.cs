using System;
using System.Collections.Generic;

namespace LMS.Model.Models;

public partial class Librarian
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public bool Active { get; set; }
}
