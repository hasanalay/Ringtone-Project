using System;
using System.Collections.Generic;

namespace App.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    public virtual ICollection<CardPayment> CardPayments { get; } = new List<CardPayment>();
}
