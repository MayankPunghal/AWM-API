using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class conditionmaster
{
    public long conditionmasterid { get; set; }

    public string conditionname { get; set; } = null!;

    public string? description { get; set; }

    public string? appliestoobject { get; set; }

    public string? whereclause { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual ICollection<accessgroupright> accessgrouprights { get; set; } = new List<accessgroupright>();
}
