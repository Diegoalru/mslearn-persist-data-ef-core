using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContosoPizza.Models;

public partial class Coupon
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;

    public DateOnly? Expiration { get; set; }
}
