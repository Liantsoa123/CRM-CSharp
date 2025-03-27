using System;
using System.Collections.Generic;

namespace Crm_CSharp.Models;

public partial class Budget
{
    public long BudgetId { get; set; }

    public string Name { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public uint CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
    
}
