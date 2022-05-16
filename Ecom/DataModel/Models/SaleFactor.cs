using Common.Entities;

namespace DataModel.Models
{
    public class SaleFactor : IEntity
    {
        public long Id { get; set; }
        public decimal TotalCost { get; set; }
        public Guid ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }

        //public ICollection<ProductSaleFactor> ProductSaleFactors { get; set; }
    }
}