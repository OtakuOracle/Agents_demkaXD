using System;
using System.Collections.Generic;

namespace Agents.Models;

public partial class Productmaterial
{
    public int Productid { get; set; }

    public int Materialid { get; set; }

    public double? Count { get; set; }

    public virtual Material Material { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
