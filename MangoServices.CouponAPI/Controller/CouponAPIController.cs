using AutoMapper;
using Azure;
using MangoServices.CouponAPI.Data;
using MangoServices.CouponAPI.Model;
using MangoServices.CouponAPI.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MangoServices.CouponAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CouponAPIController : ControllerBase
    {
        private readonly AppDbContext _db;
        private ResponseDTO _response;
        private IMapper _mapper;
        public CouponAPIController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _response = new ResponseDTO();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseDTO Get()
        {
            try
            {
                IEnumerable<Coupon> objList = _db.Coupons.ToList();
                _response.Result = objList;

            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet]
        [Route("{id:int}")] //without this, swagger cannot differentiate the two get requests
        public ResponseDTO Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(u => u.CouponId == id);
                //Control which data is passed through using the DTO
                //Instead of manually doing this we are going to use automapper
                CouponDTO couponDTO = new CouponDTO()
                {
                    CouponId = coupon.CouponId,
                    CouponCode = coupon.CouponCode,
                    DiscountAmount = coupon.DiscountAmount,
                    MinAmount = coupon.MinAmount

                };
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }


        [HttpGet]
        [Route("GetByCode:{code}")] //without this, swagger cannot differentiate the two get requests
        public ResponseDTO GetByCode(string code)
        {
            try
            {
                Coupon coupon = _db.Coupons.FirstOrDefault(u => u.CouponCode.ToLower() == code.ToLower());
                _response.Result = _mapper.Map<CouponDTO>(coupon);
                //Control which data is passed through using the DTO
                //Instead of manually doing this we are going to use automapper
                CouponDTO couponDTO = new CouponDTO()
                {
                    CouponId = coupon.CouponId,
                    CouponCode = coupon.CouponCode,
                    DiscountAmount = coupon.DiscountAmount,
                    MinAmount = coupon.MinAmount

                };
                _response.Result = coupon;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }

}