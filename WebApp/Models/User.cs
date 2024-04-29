using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();
}
