using System;
using System.Collections.Generic;

namespace PruebaApiNet.SakilaDatabase;

public partial class SalesByStore
{
    public int? StoreId { get; set; }

    public string Store { get; set; }

    public string Manager { get; set; }

    public double? TotalSales { get; set; }
}
