﻿using Common.Entities;

namespace DataModel.Models
{
    public class Category : IEntity
    {
        public long Id { get; set; }
        public long ParentId { get; set; }
        public string Title { get; set; }
    }
}