using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Firstname { get; set; } = null!;

    public string Lastname { get; set; } = null!;

    public int? Phone { get; set; }

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();
}
