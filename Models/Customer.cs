using System;
using System.Collections.Generic;

namespace Crm_CSharp.Models;

public partial class Customer
{
    public uint CustomerId { get; set; }
    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? Description { get; set; }

    public string? Position { get; set; }

    public string? Twitter { get; set; }

    public string? Facebook { get; set; }

    public string? Youtube { get; set; }

    public DateTime? CreatedAt { get; set; }

    public string? Email { get; set; }
    
    public virtual CustomerLoginInfo? Profile { get; set; }
    
    public virtual User? User { get; set; }
}
