using System;
using System.Collections.Generic;

namespace onpmysql.Models;

public partial class TwitterCopy
{
    public long C0 { get; set; }

    public string? Geo { get; set; }

    public string? Text { get; set; }

    public string? User { get; set; }

    public string? Location { get; set; }

    public string? Entities { get; set; }

    public string? Sentiment { get; set; }

    public string? Country { get; set; }
}
