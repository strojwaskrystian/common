using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sk.wpf.common.IoCModul
{
    public class ModelLocator
    {
        private static ModelLocator _instance;
        public IContainer Container { get; set; }


        public static ModelLocator Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ModelLocator();
                }
                return _instance;
            }
        }

        public ModelLocator()
        {
            var builder = new ContainerBuilder();

            Container = builder.Build();
        }


        public static T Get<T>()
        {
            using (var scopemloc = ModelLocator.Instance.Container.BeginLifetimeScope())
            {
                T identetyprovider;

                if (scopemloc.TryResolve<T>(out identetyprovider))
                {
                    return identetyprovider;
                }
                else
                {
                    return default(T);
                }
            }
        }


        public static void Update<T>(T instance) where T : class
        {
            using (var scopemloc = ModelLocator.Instance.Container.BeginLifetimeScope())
            {
                var builder = new ContainerBuilder();

                builder.RegisterInstance(instance);
                builder.Update(ModelLocator.Instance.Container);
            }
        }

    }
}
