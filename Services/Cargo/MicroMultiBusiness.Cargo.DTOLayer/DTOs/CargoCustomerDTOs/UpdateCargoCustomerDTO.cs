﻿namespace MicroMultiBusiness.Cargo.DTOLayer.DTOs.CargoCustomerDTOs
{
    public class UpdateCargoCustomerDTO
    {
        public int CargoCustomerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
