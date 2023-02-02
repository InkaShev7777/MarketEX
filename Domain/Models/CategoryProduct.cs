using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class CategoryProduct
{
    public int Id { get; private set; }

    public string Title { get; set; } = null!;
}
