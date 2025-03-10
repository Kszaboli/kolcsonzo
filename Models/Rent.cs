﻿using System;
using System.Collections.Generic;

namespace autokolcsonzo.Models;

public partial class Rent
{
    public string Id { get; set; } = null!;

    public string CustomerId { get; set; } = null!;

    public string CarId { get; set; } = null!;

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
