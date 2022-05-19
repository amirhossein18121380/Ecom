using Common.Entities;

namespace DataModel.Models
{
    public class ProductSaleFactor : IEntity
    {
        public long Id { get; set; }
        public long SaleFactorId { get; set; }
        public long ProductId { get; set; }

        //public SaleFactor SaleFactor { get; set; }
       
    }
}