using System;
using System.Collections.Generic;

namespace WebApp.Models;

public partial class Price
{
    public string Quality { get; set; } = null!;

    public int Price1 { get; set; }

    public virtual ICollection<Roomdatum> Roomdata { get; set; } = new List<Roomdatum>();
}
