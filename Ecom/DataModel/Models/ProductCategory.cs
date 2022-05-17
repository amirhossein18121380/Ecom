using Common.Entities;

namespace DataModel.Models
{
    public class ProductCategory : IEntity
    {
        public long Id { get; set; }
        public long CategoryId { get; set; }
        public long ProductId { get; set; }

     
    }
}