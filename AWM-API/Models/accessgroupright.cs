using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class accessgroupright
{
    public long accessgrouprightid { get; set; }

    public long useraccessgroupid { get; set; }

    public long rightmasterid { get; set; }

    public long conditionmasterid { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual conditionmaster conditionmaster { get; set; } = null!;

    public virtual rightmaster rightmaster { get; set; } = null!;

    public virtual useraccessgroupmaster useraccessgroup { get; set; } = null!;
}
