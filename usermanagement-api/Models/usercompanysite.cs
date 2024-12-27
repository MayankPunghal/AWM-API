using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class usercompanysite
{
    public long usercompanysiteid { get; set; }

    public int userid { get; set; }

    public string companycode { get; set; } = null!;

    public string sitecode { get; set; } = null!;

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual usermaster user { get; set; } = null!;
}
