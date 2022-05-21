using Common.Entities;

namespace Ecom.DataModel.Dtos
{
    public class CategoryDto : IDTO
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ParentId { get; set; }
    }
}