using System;
using System.Collections.Generic;

namespace onpmysql.Models;

public partial class InvoicesChild
{
    public Guid Id { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public string ContactName { get; set; } = null!;

    public string? Description { get; set; }

    public double Amount { get; set; }

    public string? InvoiceDate { get; set; }

    public string? DueDate { get; set; }

    public int Status { get; set; }

    public Guid InvoiceId { get; set; }

    public virtual ICollection<InvoicesChild> InverseInvoice { get; set; } = new List<InvoicesChild>();

    public virtual InvoicesChild Invoice { get; set; } = null!;
}
