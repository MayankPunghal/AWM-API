using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class skillmaster
{
    public long skillmasterid { get; set; }

    public string skillname { get; set; } = null!;

    public string? description { get; set; }

    public string? companycode { get; set; }

    public string? sitecode { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual ICollection<userskill> userskills { get; set; } = new List<userskill>();
}
