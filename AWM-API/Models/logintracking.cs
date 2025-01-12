using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class logintracking
{
    public long logintrackingid { get; set; }

    public int profileid { get; set; }

    public string username { get; set; } = null!;

    public string? logintriedip { get; set; }

    public DateTime logintriedon { get; set; }

    public string loginresult { get; set; } = null!;

    public bool sessionactive { get; set; }

    public DateTime sessionstarton { get; set; }

    public DateTime? sessionendon { get; set; }

    public int sessionid { get; set; }

    public int? sessionduration { get; set; }

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual usermaster profile { get; set; } = null!;
}
