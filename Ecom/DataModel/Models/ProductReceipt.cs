using Common.Entities;

namespace DataModel.Models
{
    public class ProductReceipt : IEntity
    {
        public long Id { get; set; }
        public long ReceiptId { get; set; }
        public long ProductId { get; set; }

        //public Receipt Receipt { get; set; }
    }
}