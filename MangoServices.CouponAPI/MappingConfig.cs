using AutoMapper;
using MangoServices.CouponAPI.Model;
using MangoServices.CouponAPI.Model.DTO;

namespace MangoServices.CouponAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                //We want to be able to map it both ways 
                //This prevents us for having to initialise CouponDTO with fetched
                //- coupon data from the db or initalise Coupon objects with CouponDTO data
                
                //Mapping only works when object variables have the exact same name
                config.CreateMap<CouponDTO,Coupon>();
                config.CreateMap<Coupon, CouponDTO>();
            }
            );
            return mappingConfig;
            
        }
    }
}
