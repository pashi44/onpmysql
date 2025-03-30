using System;
using System.Collections.Generic;

namespace onpmysql.Models;

public partial class CoronaCopy
{
    public long CountryId { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public double? Lat { get; set; }

    public double? Longi { get; set; }

    public DateOnly? Date { get; set; }

    public int? Confirmed { get; set; }

    public short? Death { get; set; }

    public int? Recovered { get; set; }

    public string? StateCleaned { get; set; }

    public string? City { get; set; }
}
