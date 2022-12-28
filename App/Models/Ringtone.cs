using System;
using System.Collections.Generic;

namespace App.Models;

public partial class Ringtone
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Artist { get; set; }

    public string? Imageurl { get; set; }

    public string? Audiourl { get; set; }

    public int? CategoryId { get; set; }

    public decimal? Price { get; set; }

    public string? Details { get; set; }

    public virtual ICollection<CardPayment> CardPayments { get; } = new List<CardPayment>();

    public virtual Category? Category { get; set; }
}
