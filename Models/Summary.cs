using System;
using System.Collections.Generic;

namespace onpmysql.Models;

public partial class Summary
{
    public string? DestCountryName { get; set; }

    public string? OriginCountryName { get; set; }

    public int? Count { get; set; }
}
