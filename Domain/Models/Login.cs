using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Login
{
    public int Id { get; private set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;
}
