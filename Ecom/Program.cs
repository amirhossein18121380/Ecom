using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Businesses.Abstract;
using Businesses.Concrete;
using Businesses.Mappings;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Ecom.business.Abstract;
using Ecom.business.Concrete;
using Ecom.Common.Utilities;
using Ecom.DataAccess.Abstract;
using Ecom.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EcomContext>(options =>

    options.UseSqlServer(builder.Configuration.GetConnectionString("EcomContext") ?? throw new InvalidOperationException("Connection string 'EcomContext' not found.")));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDependencyResolvers(builder.Configuration, new ICoreModule[] {
    new CoreModule()
});

builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<IProductCategoryRepository, EfProductCategoryRepository>();
builder.Services.AddScoped<IProductReceiptRepository, EFProductReceiptRepository>();
builder.Services.AddScoped<IProductSaleFactorRepository, EfProductSaleFactorRepository>();
builder.Services.AddScoped<IRecriptRepository, EfRecriptRepository>();
builder.Services.AddScoped<ISaleFactorRepository, EFSaleFactorRepository>();
//builder.Services.AddScoped<Automapper>();



builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IReceiptService, ReceiptManager>();
builder.Services.AddScoped<ISaleFactoryService, SaleFactoryManager>();

builder.Services.AddAutofac();

// Auto Mapper Configurations
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new Automapper());
});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//builder.Services.AddAutoMapper();

Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());
    });

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
