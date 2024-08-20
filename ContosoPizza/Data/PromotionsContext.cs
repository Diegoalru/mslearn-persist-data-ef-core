using System;
using System.Collections.Generic;
using ContosoPizza.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Data;

public partial class PromotionsContext(DbContextOptions<PromotionsContext> options) : DbContext(options)
{
    public virtual DbSet<Coupon> Coupons { get; set; }
}
