﻿using System;
using System.Collections.Generic;

namespace autokolcsonzo.Models;

public partial class Car
{
    public string Id { get; set; } = null!;

    public string Marka { get; set; } = null!;

    public string Model { get; set; } = null!;

    public DateTime Evjarat { get; set; }

    public virtual ICollection<Rent> Rents { get; set; } = new List<Rent>();
}
