using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class useraccessgroupmaster
{
    public long useraccessgroupid { get; set; }

    public string accessgroupname { get; set; } = null!;

    public string? description { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime rcreate { get; set; }

    public DateTime rupdate { get; set; }

    public DateTime revent { get; set; }

    public virtual ICollection<accessgroupright> accessgrouprights { get; set; } = new List<accessgroupright>();
}
