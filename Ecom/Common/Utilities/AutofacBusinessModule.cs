using System.Reflection;
using Autofac;
using AutoMapper;
using Businesses.Abstract;
using Businesses.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Ecom.business.Abstract;
using Ecom.business.Concrete;
using Ecom.DataAccess.Abstract;
using Ecom.DataAccess.Concrete.EntityFramework;
using Autofac.Extras.DynamicProxy;

namespace Ecom.Common.Utilities
{
    public class AutofacBusinessModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
 
            
            builder.RegisterType<EfProductSaleFactorRepository>().As<IProductSaleFactorRepository>().InstancePerLifetimeScope();
            
            builder.RegisterType<EFProductReceiptRepository>().As<IProductReceiptRepository>().InstancePerLifetimeScope();
            
            builder.RegisterType<EfProductCategoryRepository>().As<IProductCategoryRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ReceiptManager>().As<IReceiptService>().InstancePerLifetimeScope();
            builder.RegisterType<EfRecriptRepository>().As<IRecriptRepository>().InstancePerLifetimeScope();

            builder.RegisterType<SaleFactoryManager>().As<ISaleFactoryService>().InstancePerLifetimeScope();
            builder.RegisterType<EFSaleFactorRepository>().As<ISaleFactorRepository>().InstancePerLifetimeScope();

            builder.RegisterType<ProductManager>().As<IProductService>().InstancePerLifetimeScope();
            builder.RegisterType<EfProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly)
                .Where(t => typeof(Profile).IsAssignableFrom(t) && !t.IsAbstract && t.IsPublic)
                .As<Profile>();

            builder.Register(c => new MapperConfiguration(cfg => {
                foreach (var profile in c.Resolve<IEnumerable<Profile>>())
                {
                    cfg.AddProfile(profile);
                }
            })).AsSelf().SingleInstance();

            builder.Register(c => c.Resolve<MapperConfiguration>()
                .CreateMapper(c.Resolve))
                .As<IMapper>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                            {
                                Selector = new AspectInterceptorSelector()
                            }).SingleInstance().InstancePerDependency();
        }


    }
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(MsSqlLogger)));
            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
