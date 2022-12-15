using System;
using System.Collections.Generic;

namespace App.Models;

public partial class CardPayment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? RingtoneId { get; set; }

    public string TransactionId { get; set; }

    public decimal? Amount { get; set; }

    public virtual Ringtone Ringtone { get; set; }

    public virtual User User { get; set; }
}
