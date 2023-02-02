using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Registr
{
    public int Id { get; private set; }

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
}
