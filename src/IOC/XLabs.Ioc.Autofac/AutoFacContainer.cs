using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLabs.Ioc.Autofac
{
    /// <summary>
    /// The AutoFac container wrapper
    /// Allows registering a AutoFac container with the IDependencyContainer interface
    /// </summary>
    public class AutofacContainer : IDependencyContainer
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly IContainer container;
        /// <summary>
        /// Initializes a new instance of the <see cref="AutofacContainer"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public AutofacContainer(IContainer container)
        {
            this.container = container;
        }
        /// <summary>
        /// The get resolver.
        /// </summary>
        /// <returns>
        /// The <see cref="IResolver"/>.
        /// </returns>
        public IResolver GetResolver()
        {
            return new AutofacResolver(this.container);
        }
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="instance">
        /// The instance.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IDependencyContainer"/>.
        /// </returns>
        public IDependencyContainer Register<T>(T instance) where T : class
        {
            var builder = new ContainerBuilder();
            builder.Register<T>(t => instance);
            builder.Update(container);
            return this;
        }
        /// <summary>
        /// The register.
        /// </summary>
        /// <typeparam name="T">
        /// </typeparam>
        /// <typeparam name="TImpl">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IDependencyContainer"/>.
        /// </returns>
        public IDependencyContainer Register<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TImpl>().As<T>();
            builder.Update(container);
            return this;
        }
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="IDependencyContainer"/>.
        /// </returns>
        public IDependencyContainer Register<T>(Type type) where T : class
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(type);
            builder.Update(container);
            return this;
        }
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="impl">
        /// The impl.
        /// </param>
        /// <returns>
        /// The <see cref="IDependencyContainer"/>.
        /// </returns>
        public IDependencyContainer Register(Type type, Type impl)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType(impl).As(type);
            builder.Update(container);
            return this;
        }
        public IDependencyContainer Register<T>(Func<IResolver, T> func) where T : class
        {
            var builder = new ContainerBuilder();
            var resolver = func.Invoke(GetResolver());
            this.Register<T>(resolver);
            return this;
        }


        public IDependencyContainer RegisterSingle<T, TImpl>()
            where T : class
            where TImpl : class, T
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<TImpl>().As<T>().SingleInstance();
            builder.Update(container);
            return this;
        }
    }
}
