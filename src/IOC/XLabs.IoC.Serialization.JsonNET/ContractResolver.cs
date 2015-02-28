namespace XLabs.IoC.Serialization.JsonNET
{
	using System;

	using Newtonsoft.Json.Serialization;

	using XLabs.Ioc;

	/// <summary>
	/// Class ContractResolver.
	/// </summary>
	public class ContractResolver : DefaultContractResolver
	{
		private readonly IResolver _container;

		/// <summary>
		/// Initializes a new instance of the <see cref="ContractResolver"/> class.
		/// </summary>
		/// <param name="container">The container.</param>
		public ContractResolver(IResolver container)
		{
			_container = container;
		}

		/// <summary>
		/// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract" /> for the given type.
		/// </summary>
		/// <param name="objectType">Type of the object.</param>
		/// <returns>A <see cref="T:Newtonsoft.Json.Serialization.JsonObjectContract" /> for the given type.</returns>
		protected override JsonObjectContract CreateObjectContract(Type objectType)
		{
			var contract = base.CreateObjectContract(objectType);

			// use Resolver to create types that have been registered with it
			if (_container.IsRegistered(objectType))
			{
				contract.DefaultCreator = () => _container.Resolve(objectType);
			}

			return contract;
		}
	}
}
