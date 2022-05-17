using Common.Entities;

namespace Ecom.DataModel.Dtos
{
    public class CategoryDto : IDTO
    {
        public string Title { get; set; }
        public long ParentId { get; set; }
    }
}