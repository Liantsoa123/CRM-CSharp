using System;
using System.Collections.Generic;

namespace Crm_CSharp.Models;

public partial class Expense
{
    public long ExpenseId { get; set; }

    public decimal Amount { get; set; }

    public DateOnly Date { get; set; }

    public string? Description { get; set; }
    
    public virtual Budget? Budget { get; set; } = null!;
}
