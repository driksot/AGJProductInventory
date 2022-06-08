﻿using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.CustomerAddress.Commands.CreateCustomerAddressCommand
{
    public class CreateCustomerAddressDTO : ICustomerAddressDTO
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
