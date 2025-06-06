﻿using System;
using System.Collections.Generic;

namespace Crm_CSharp.Models;

public partial class LeadAction
{
    public uint Id { get; set; }

    public uint LeadId { get; set; }

    public string? Action { get; set; }

    public DateTime? DateTime { get; set; }

    public virtual Lead Lead { get; set; } = null!;
}
