using System;
using System.Collections.Generic;

namespace HotelLibrary.Models;

public partial class Roomdatum
{
    public int Id { get; set; }

    public int RoomNumber { get; set; }

    public int NumberOfBeds { get; set; }

    public int RoomSize { get; set; }

    public string RoomQuality { get; set; } = null!;

    public virtual ICollection<Bookingdatum> Bookingdata { get; set; } = new List<Bookingdatum>();
}
