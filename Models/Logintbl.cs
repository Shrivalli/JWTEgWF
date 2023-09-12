using System;
using System.Collections.Generic;

namespace JWTEg.Models;

public partial class Logintbl
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public bool IsEmployee { get; set; }
}
