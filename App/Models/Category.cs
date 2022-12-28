using System;
using System.Collections.Generic;

namespace App.Models;

public partial class Category
{
    public int Id { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Ringtone> Ringtones { get; } = new List<Ringtone>();
}
