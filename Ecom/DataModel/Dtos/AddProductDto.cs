using Common.Entities;
using DataModel.Models;

namespace Ecom.DataModel.Dtos
{
    public class AddProductDto : IDTO
    {
        //public long Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public IList<Category> Categories { get; set; }
    }
}
