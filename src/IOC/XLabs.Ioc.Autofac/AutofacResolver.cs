﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Autofac;

namespace XLabs.Ioc.Autofac
{
	/// <summary>
	/// The Autofac resolver.
	/// </summary>
	[SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
	public class AutofacResolver : IResolver
	{
		private readonly IContainer container;

		/// <summary>
		/// Initializes a new instance of the <see cref="AutofacResolver"/> class.
		/// </summary>
		/// <param name="container">
		/// The container.
		/// </param>
		public AutofacResolver(IContainer container)
		{
			this.container = container;
		}

		#region IResolver Members

		/// <summary>
		/// Resolve a dependency.
		/// </summary>
		/// <typeparam name="T">Type of instance to get.</typeparam>
		/// <returns>An instance of {T} if successful, otherwise null.</returns>
		public T Resolve<T>() where T : class
		{
			return this.container.ResolveOptional<T>();
		}

		/// <summary>
		/// Resolve a dependency by type.
		/// </summary>
		/// <param name="type">Type of object.</param>
		/// <returns>An instance to type if found as <see cref="object"/>, otherwise null.</returns>
		public object Resolve(Type type)
		{
			return this.container.ResolveOptional(type);
		}

		/// <summary>
		/// Resolve a dependency.
		/// </summary>
		/// <typeparam name="T">Type of instance to get.</typeparam>
		/// <returns>All instances of {T} if successful, otherwise null.</returns>
		public IEnumerable<T> ResolveAll<T>() where T : class
		{
			return new[] { this.Resolve<T>() };
		}

		/// <summary>
		/// Resolve a dependency by type.
		/// </summary>
		/// <param name="type">Type of object.</param>
		/// <returns>All instances of type if found as <see cref="object"/>, otherwise null.</returns>
		public IEnumerable<object> ResolveAll(Type type)
		{
			return new[] { this.Resolve(type) };
		}

		/// <summary>
		/// Determines whether the specified type is registered.
		/// </summary>
		/// <param name="type">The type.</param>
		/// <returns><c>true</c> if the specified type is registered; otherwise, <c>false</c>.</returns>
		public bool IsRegistered(Type type)
		{
			return this.container.IsRegistered(type);
		}

		/// <summary>
		/// Determines whether this instance is registered.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns><c>true</c> if this instance is registered; otherwise, <c>false</c>.</returns>
		public bool IsRegistered<T>() where T : class
		{
			return this.container.IsRegistered<T>();
		}
		#endregion
	}
}
