﻿namespace Web.Api.Entities.Suppliers
{
    public class Supplier
    {
        public Guid Id { get; set; }
        public string SupplierName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}