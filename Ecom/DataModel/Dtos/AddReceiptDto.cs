using Common.Entities;

namespace Ecom.DataModel.Dtos
{
    public class AddReceiptDto: IDTO
    {
        public decimal TotalCost { get; set; }
        public long ReceiptNumber { get; set; }
        public DateTime ReceiptDate { get; set; }
    }
}