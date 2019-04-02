using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using T.Common.Interface;

namespace T.Web.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAll()
        {
            var builder = new ContainerBuilder();
            Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();
            Type baseType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                .AsSelf().AsImplementedInterfaces()
                .PropertiesAutowired().InstancePerLifetimeScope();//InstancePerLifetimeScope 保证生命周期基于请求

            //注册dbcontext
            Type dbBaseType = typeof(DbContext);
            builder.RegisterAssemblyTypes(assemblies)
                .Where(type => dbBaseType.IsAssignableFrom(type) && !type.IsAbstract)
                .InstancePerRequest();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterFilterProvider();
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}