using System;
using System.Collections.Generic;

namespace DataAccessEF;

public partial class Product
{
    public int Id { get; private set; }

    public string Title { get; set; } = null!;

    public string Model { get; set; } = null!;

    public double Price { get; set; }

    public string Img { get; set; } = null!;

    public int CategoryId { get; set; }

    public int Amount { get; set; }

    public string Status { get; set; } = null!;
}
