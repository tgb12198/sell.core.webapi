using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace sell.webapi.Common.Utils
{
    public class CopyHelper
    {
        /// <summary>
        /// 反射实现两个类的对象之间相同属性的值的复制
        /// 适用于初始化新实体
        /// </summary>
        /// <typeparam name="Current">返回的实体</typeparam>
        /// <typeparam name="Original">数据源实体</typeparam>
        /// <param name="original">数据源实体</param>
        /// <returns>返回的新实体</returns>
        public static Current Mapper<Current, Original>(Original original)
        {
            Current current = Activator.CreateInstance<Current>(); //构造新实例
            try
            {
                var Types = original.GetType();//获得类型  
                var Typed = typeof(Current);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")//判断属性名是否相同  
                        {
                            dp.SetValue(current, sp.GetValue(original, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return current;
        }

        /// <summary>
        /// 反射实现两个类的对象之间相同属性的值的复制
        /// 适用于没有新建实体之间
        /// </summary>
        /// <typeparam name="Current">返回的实体</typeparam>
        /// <typeparam name="Original">数据源实体</typeparam>
        /// <param name="current">返回的实体</param>
        /// <param name="original">数据源实体</param>
        /// <returns></returns>
        public static Current CopyTo<Current, Original>(Current current, Original original)
        {
            try
            {
                var Types = original.GetType();//获得类型  
                var Typed = typeof(Current);
                foreach (PropertyInfo sp in Types.GetProperties())//获得类型的属性字段  
                {
                    foreach (PropertyInfo dp in Typed.GetProperties())
                    {
                        if (dp.Name == sp.Name && dp.PropertyType == sp.PropertyType && dp.Name != "Error" && dp.Name != "Item")//判断属性名是否相同  
                        {
                            dp.SetValue(current, sp.GetValue(original, null), null);//获得s对象属性的值复制给d对象的属性  
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return current;
        }
    }
}
