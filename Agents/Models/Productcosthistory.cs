using System;
using System.Collections.Generic;

namespace Agents.Models;

public partial class Productcosthistory
{
    public int Id { get; set; }

    public int Productid { get; set; }

    public DateTime Changedate { get; set; }

    public decimal Costvalue { get; set; }

    public virtual Product Product { get; set; } = null!;
}
