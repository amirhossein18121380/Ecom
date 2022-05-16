using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Entities;
using DataModel.Models;

namespace DataModel.Dtos
{
    public class SaleFactorDto : IDTO
    {
        public IList<long> ProductIds { get; set; }
    }
}
