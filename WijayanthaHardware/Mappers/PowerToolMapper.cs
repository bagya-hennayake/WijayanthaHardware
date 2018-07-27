using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WijayanthaHardware.Entities;
using WijayanthaHardware.Models;

namespace WijayanthaHardware.Mappers
{
    public static class PowerToolMapper
    {
        public static PowerToolsViewModel BuildPowerToolsViewModel(PowerToolMaster powerToolMaster)
        {
            return new PowerToolsViewModel
            {
                ToolName = powerToolMaster.PowerToolSubCatogery.Value,
                ToolPrice = powerToolMaster.Price,
                CostCode = powerToolMaster.CostCode,
                Details = powerToolMaster.PowerToolSubCatogery.Description,
                WarrantyPeriod = powerToolMaster.WarrantyPeriod,
                AvailableQuantity = powerToolMaster.Quantity
            };
        }
    }
}