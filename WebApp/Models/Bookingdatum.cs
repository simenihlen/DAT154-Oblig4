using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Bookingdatum
{
    public int Id { get; set; }

    public int Roomid { get; set; }

    public int Userid { get; set; }

    public DateTime Startdate { get; set; }

    public DateTime Enddate { get; set; }

    public virtual Roomdatum Room { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
