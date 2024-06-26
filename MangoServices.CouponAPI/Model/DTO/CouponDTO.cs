namespace MangoServices.CouponAPI.Model.DTO
{
    public class CouponDTO
    {
        public int CouponId { get; set; }
        public string CouponCode { get; set; }
        public double DiscountAcount { get; set; }
        public int MinAmount { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
