

using Common.Entities;

namespace DataModel.Models
{
    public class Product : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Code { get; set; }
        public string Description { get; set; }
        public DateTime Createon { get; set; }

        public ProductCategory productCategory { get; set; }
    }
}