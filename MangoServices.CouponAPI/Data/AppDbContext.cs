using MangoServices.CouponAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace MangoServices.CouponAPI.Data
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        }

        //name of table in database
        public DbSet<Coupon> Coupons { get; set; }
    }
}
