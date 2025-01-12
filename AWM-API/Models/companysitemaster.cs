using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class companysitemaster
{
    public long companysitemasterid { get; set; }

    public string? description { get; set; }

    public string? companysite { get; set; }

    public string? companycode { get; set; }

    public string? companyname { get; set; }

    public string? sitecode { get; set; }

    public string? sitename { get; set; }

    public bool? active { get; set; }

    public int? sequenceno { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }
}
