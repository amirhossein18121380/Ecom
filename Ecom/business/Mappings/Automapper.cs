using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.Dtos;
using DataModel.Models;
using Ecom.DataModel.Dtos;

namespace Businesses.Mappings
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            // AuthManager Mappings
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Receipt, ReceiptDto>().ReverseMap();
            CreateMap<SaleFactor, SaleFactorDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<SaleFactor, AddSaleFactorDto>().ReverseMap();
            CreateMap<Receipt, AddReceiptDto>().ReverseMap();
        }
    }
}