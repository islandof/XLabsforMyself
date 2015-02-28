using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XLabs.Ioc.TinyIOC
{
    using TinyIoC;

    /// <summary>
    /// The tiny container wrapper
    /// Allows registering a tinyioc container with the IDependencyContainer interface
    /// </summary>
    public class TinyContainer : IDependencyContainer
    {
        /// <summary>
        /// The container.
        /// </summary>
        private readonly TinyIoCContainer container;

        /// <summary>
        /// Initializes a new instance of the <see cref="TinyContainer"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public TinyContainer(TinyIoCContainer container)
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
            return new TinyResolver(this.container);
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
            this.container.Register<T>(instance);
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
        public IDependencyContainer Register<T, TImpl>() where T : class where TImpl : class, T
        {
            this.container.Register<T, TImpl>();
            return this;
        }

        public IDependencyContainer RegisterSingle<T, TImpl>() where T : class where TImpl : class, T
        {
            this.container.Register<T, TImpl>().AsSingleton();
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
            this.container.Register(type);
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
            this.container.Register(type, impl);
            return this;
        }

        public IDependencyContainer Register<T>(Func<IResolver, T> func) where T : class
        {
            Func<TinyIoCContainer,NamedParameterOverloads,T> f;

            f = (c, t) => func(new TinyResolver(c));

            this.container.Register<T>(f);
            return this;
        }
    }
}
