using System;
using System.Collections.Generic;

namespace Crm_CSharp.Models;

public partial class Lead
{
    public uint LeadId { get; set; }

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Status { get; set; }

    public string? MeetingId { get; set; }

    public bool? GoogleDrive { get; set; }

    public string? GoogleDriveFolderId { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual User? Employee { get; set; }

    public virtual Expense? Expense { get; set; }

    public virtual ICollection<File> Files { get; set; } = new List<File>();

    public virtual ICollection<GoogleDriveFile> GoogleDriveFiles { get; set; } = new List<GoogleDriveFile>();

    public virtual ICollection<LeadAction> LeadActions { get; set; } = new List<LeadAction>();
    
    public virtual User? Manager { get; set; }
}
