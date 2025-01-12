using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class shiftmaster
{
    public long shiftmasterid { get; set; }

    public string shiftname { get; set; } = null!;

    public TimeOnly shiftstart { get; set; }

    public string? companycode { get; set; }

    public string? sitecode { get; set; }

    public string? status { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updatedby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }
}
