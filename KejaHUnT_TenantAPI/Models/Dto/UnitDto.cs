﻿using Microsoft.EntityFrameworkCore;

namespace KejaHUnT_TenantAPI.Models.Dto
{
    public class UnitDto
    {
        [Precision(18, 2)]
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Bathrooms { get; set; }
        public double Size { get; set; }
        public int NoOfUnits { get; set; }
    }
}
