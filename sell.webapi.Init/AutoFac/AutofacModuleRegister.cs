using Autofac;
using sell.webapi.DataBase;
using sell.webapi.IServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace sell.webapi.Init.AutoFac
{
    public class AutofacModuleRegister : Autofac.Module
    {
        /// <summary>
        /// 重写Autofac管道Load方法，在这里注册注入
        /// </summary>
        /// <param name="builder"></param>
        protected override void Load(ContainerBuilder builder)
        {
            //注册Service中的对象（两种获取方式：1：继承了IDependency的类，2：以Service结尾的类）
            //Assembly[] assemblies = Directory.GetFiles(AppDomain.CurrentDomain.RelativeSearchPath, "*.dll").Select(Assembly.LoadFrom).ToArray();
            ////注册所有实现了 IDependency 接口的类型
            var assemblies = Assembly.Load("sell.webapi.Services");
            Type baseType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblies)
                       .Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
                       .AsSelf().AsImplementedInterfaces()
                       .InstancePerLifetimeScope();
            //注册所有以Service结束的类
            //var iService = Assembly.Load("sell.webapi.IServices");
            //var service = Assembly.Load("sell.webapi.Services");
            ////根据名称约定（服务层的接口和实现均以Service结尾），实现服务接口和服务实现的依赖
            //builder.RegisterAssemblyTypes(iService, service)
            //  .Where(t => t.Name.EndsWith("Service"))
            //  .AsImplementedInterfaces();

            //注册Respository中的对象
            var iRepository = Assembly.Load("sell.webapi.IRepository");
            var repository = Assembly.Load("sell.webapi.Repository");
            //根据名称约定（数据访问层的接口和实现均以Repository结尾），实现数据访问接口和数据访问实现的依赖
            builder.RegisterAssemblyTypes(iRepository, repository)
              .Where(t => t.Name.EndsWith("Repository"))
              .AsImplementedInterfaces();

            //注册DbContext对象
            builder.Register(x => new DbContext()).As<IDbContext>();
            //注册Controller中的对象
            builder.RegisterAssemblyTypes(GetAssemblyByName("sell.webapi"))
                .Where(a => a.Name.EndsWith("Controller"))
                .PublicOnly()
                .Where(a => a.IsClass)
                .InstancePerDependency()
                .PropertiesAutowired();
        }

        /// <summary>
        /// 根据程序集名称获取程序集
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        private static Assembly[] GetAssemblyByName(string assemblyName)
        {
            var assemblys = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetFiles(assemblyName).
                Select(c => Assembly.LoadFrom(c.FullName));
            return assemblys.ToArray();
        }
    }
}
