using System;
using System.Collections.Generic;

namespace Domain.Models;

public partial class Product
{
    public int Id { get;  set; }

    public string Title { get; set; } = null!;

    public string Model { get; set; } = null!;

    public double Price { get; set; }

    public int IdCategory { get; set; }

    public string UriPhoto { get; set; } = null!;

    public int Amount { get; set; }

    public string Status { get; set; } = null!;
}
