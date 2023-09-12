using System;
using System.Collections.Generic;

namespace JWTEg.Models;

public partial class Account
{
    public int Accno { get; set; }

    public int? Custid { get; set; }

    public DateTime? Doc { get; set; }

    public string? Actype { get; set; }

    public virtual Customer? Cust { get; set; }
}
