using System;
using System.Collections.Generic;

namespace Crm_CSharp.Models;

public partial class User
{
    public int Id { get; set; }
    
    public string Email { get; set; } = null!;

    public string? Password { get; set; }

    public DateTime? HireDate { get; set; }

    public DateTime? CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
    public string Username { get; set; } = null!;

    public string? Status { get; set; }

    public string? Token { get; set; }

    public bool? IsPasswordSet { get; set; }
    
    public virtual ICollection<OauthUser> OauthUsers { get; set; } = new List<OauthUser>();
    
    public virtual ICollection<UserProfile> UserProfiles { get; set; } = new List<UserProfile>();

    public virtual ICollection<Role> Roles { get; set; } = new List<Role>();
}
