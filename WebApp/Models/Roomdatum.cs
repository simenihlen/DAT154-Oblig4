using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Roomdatum
{
    public int Id { get; set; }

    public string Quality { get; set; } = null!;

    public int Beds { get; set; }

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();

    public virtual Price QualityNavigation { get; set; } = null!;
}
