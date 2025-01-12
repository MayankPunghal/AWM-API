using System;
using System.Collections.Generic;

namespace usermanagement_api.Models;

public partial class usermaster
{
    public int profileid { get; set; }

    public string username { get; set; } = null!;

    public string firstname { get; set; } = null!;

    public string? middlename { get; set; }

    public string? lastname { get; set; }

    public string displayname { get; set; } = null!;

    public string contactno { get; set; } = null!;

    public string? contactno1 { get; set; }

    public string addressline1 { get; set; } = null!;

    public string? addressline2 { get; set; }

    public string? addressline3 { get; set; }

    public string city { get; set; } = null!;

    public string? state { get; set; }

    public string? district { get; set; }

    public string? town { get; set; }

    public string country { get; set; } = null!;

    public string zipcode { get; set; } = null!;

    public int? managerid { get; set; }

    public string? managername { get; set; }

    public string password { get; set; } = null!;

    public string? emailid { get; set; }

    public string? mfatoken { get; set; }

    public DateTime createddate { get; set; }

    public string createdby { get; set; } = null!;

    public DateTime lastupdated { get; set; }

    public string updateby { get; set; } = null!;

    public DateTime? rcreate { get; set; }

    public DateTime? rupdate { get; set; }

    public string? revent { get; set; }

    public virtual ICollection<usermaster> Inversemanager { get; set; } = new List<usermaster>();

    public virtual ICollection<logintracking> logintrackings { get; set; } = new List<logintracking>();

    public virtual usermaster? manager { get; set; }

    public virtual ICollection<usercompanysite> usercompanysites { get; set; } = new List<usercompanysite>();

    public virtual ICollection<userskill> userskills { get; set; } = new List<userskill>();
}
