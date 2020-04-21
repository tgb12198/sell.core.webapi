using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using sell.webapi.Init.AutoFac;
using System;
using System.Collections.Generic;
using System.Text;

namespace sell.webapi.Init.AutoFac
{
    public static class AutofacRegister
    {
        public static IServiceProvider RegisterAutofac(IServiceCollection services)
        {
            //实例化autofac容器
            var builder = new ContainerBuilder();
            //将services中的服务填充到autofac中
            builder.Populate(services);
            //新模块组件注册
            builder.RegisterModule<AutofacModuleRegister>();
            //创建容器
            var container = builder.Build();
            //第三方IOC接管，core内置DI容器
            return new AutofacServiceProvider(container);
        }
    }
}
