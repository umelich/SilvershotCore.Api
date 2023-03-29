using System;
using System.Collections.Generic;

namespace SilvershotCore.DataModels;

public partial class Item
{
    public int ItemId { get; set; }

    public string? ItemCode { get; set; }

    public string ItemName { get; set; } = null!;

    public decimal? ItemPrice { get; set; }

    public string? ItemDetails { get; set; }
}
