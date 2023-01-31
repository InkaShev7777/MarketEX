using System;
using System.Collections.Generic;

namespace DataAccessEF;

public partial class CategoryProduct
{
    public int Id { get; private set; }

    public string Title { get; set; } = null!;
}
