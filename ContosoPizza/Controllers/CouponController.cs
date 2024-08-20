using ContosoPizza.Data;
using ContosoPizza.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class CouponController (PromotionsContext _context) : ControllerBase
{
    [HttpGet]
    public IEnumerable<Coupon> Get()
    {
        return [.. _context.Coupons.AsNoTracking()];
    }
}