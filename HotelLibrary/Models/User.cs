﻿using System;
using System.Collections.Generic;

namespace HotelLibrary.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Role { get; set; }

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();
}
