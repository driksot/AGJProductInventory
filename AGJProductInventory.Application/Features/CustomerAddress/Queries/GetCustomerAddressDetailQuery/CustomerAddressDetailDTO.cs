﻿using AGJProductInventory.Application.Common;

namespace AGJProductInventory.Application.Features.CustomerAddress.Queries.GetCustomerAddressDetailQuery
{
    public class CustomerAddressDetailDTO : BaseDTO, ICustomerAddressDTO
    {
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}