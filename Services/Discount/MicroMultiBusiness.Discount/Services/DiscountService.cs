using Dapper;
using MicroMultiBusiness.Discount.Context;
using MicroMultiBusiness.Discount.DTOs;

namespace MicroMultiBusiness.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;

        public DiscountService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateDiscountCouponAsync(CreateDiscountCouponDTO createCouponDTO)
        {
            string query = "INSERT INTO Coupons (Code, Rate, IsActive, ValidDate) VALUES (@code, @rate, @isActive, @validDate)";
            var parameters = new DynamicParameters();
            parameters.Add("@code", createCouponDTO.Code);
            parameters.Add("@rate", createCouponDTO.Rate);
            parameters.Add("@isActive", createCouponDTO.IsActive);
            parameters.Add("@validDate", createCouponDTO.ValidDate);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            } //dapper add syntax
        }

        public async Task DeleteDiscountCouponAsync(int id)
        {
            string query = "DELETE FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            } //dapper delete syntax
        }

        public async Task<List<ResultDiscountCouponDTO>> GetAllDiscountCouponsAsync()
        {
            string query = "SELECT * FROM Coupons";
            using(var connection = _dapperContext.CreateConnection())
            {
                var coupons = await connection.QueryAsync<ResultDiscountCouponDTO>(query);
                return coupons.ToList();
            } //dapper select syntax
        }

        public async Task<GetByIdDiscountCouponDTO> GetByIdDiscountCouponAsync(int id)
        {
            string query = "SELECT * FROM Coupons WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@couponId", id);
            using(var connection = _dapperContext.CreateConnection())
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountCouponDTO>(query, parameters);
                return coupon;
            } //dapper select syntax
        }

        public async Task<GetDiscountDetailByCouponCodeDTO> GetDiscountDetailByCouponCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE Code = @code";
            var parameters = new DynamicParameters();
            parameters.Add("@code", code);
            using (var connection = _dapperContext.CreateConnection())
            {
                var coupon = await connection.QueryFirstOrDefaultAsync<GetDiscountDetailByCouponCodeDTO>(query, parameters);
                return coupon;
            } //dapper select syntax
        }

        public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDTO updateCouponDTO)
        {
            string query = "UPDATE Coupons SET Code = @code, Rate = @rate, IsActive = @isActive, ValidDate = @validDate WHERE CouponId = @couponId";
            var parameters = new DynamicParameters();
            parameters.Add("@code", updateCouponDTO.Code);
            parameters.Add("@rate", updateCouponDTO.Rate);
            parameters.Add("@isActive", updateCouponDTO.IsActive);
            parameters.Add("@validDate", updateCouponDTO.ValidDate);
            parameters.Add("@couponId", updateCouponDTO.CouponId);
            using(var connection = _dapperContext.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            } //dapper update syntax
        }
    }
}
