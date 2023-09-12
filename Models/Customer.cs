using System;
using System.Collections.Generic;

namespace JWTEg.Models;

public partial class Customer
{
    public int Cid { get; set; }

    public string? Cname { get; set; }

    public DateTime? Doj { get; set; }

    public string? Cadd { get; set; }

    public double? Bal { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
