using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace sell.webapi.Common
{
    public class Singleton<T> where T : class, new()
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                var instance = _instance;
                if (instance == null)
                {
                    instance = Volatile.Read(ref _instance);
                    if (instance == null)
                    {
                        instance = new T();
                    }
                    Volatile.Write(ref _instance, instance);
                }
                return instance;
            }
        }
    }
}
