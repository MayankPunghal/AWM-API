using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class userskill
{
    public long userskillid { get; set; }

    public int userid { get; set; }

    public long skillmasterid { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual skillmaster skillmaster { get; set; } = null!;

    public virtual usermaster user { get; set; } = null!;
}
