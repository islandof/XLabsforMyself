using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace XLabs.Ioc.Unity
{
    public class UnityDependencyContainer : IDependencyContainer
    {
        private readonly UnityContainer container;
        private readonly IResolver resolver;

        public UnityDependencyContainer() : this(new UnityContainer())
        {
            
        }

        public UnityDependencyContainer(UnityContainer container)
        {
            this.container = container;
            this.resolver = new UnityResolver(this.container);
        }

        #region IDependencyContainer Members

        public IResolver GetResolver()
        {
            return this.resolver;
        }

        public IDependencyContainer Register<T>(T instance) where T : class
        {
            this.container.RegisterInstance<T>(instance);
            return this;
        }

        public IDependencyContainer Register<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            this.container.RegisterType<T, TImpl>();
            return this;
        }

        public IDependencyContainer RegisterSingle<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            this.container.RegisterType<T, TImpl>(new ContainerControlledLifetimeManager());
            return this;
        }

        public IDependencyContainer Register<T>(Type type) where T : class
        {
            return this.Register(typeof(T), type);
        }

        public IDependencyContainer Register(Type type, Type impl)
        {
            this.container.RegisterType(type, impl);
            return this;
        }

        public IDependencyContainer Register<T>(Func<IResolver, T> func) where T : class
        {
            throw new NotImplementedException("Unity container does not support registering funcs for resolving.");
        }

        #endregion
    }
}
