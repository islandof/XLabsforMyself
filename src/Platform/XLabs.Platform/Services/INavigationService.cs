namespace XLabs.Platform.Services
{
	using System;

	/// <summary>
	/// Interface INavigationService
	/// </summary>
	public interface INavigationService
	{
		/// <summary>
		/// Registers the page (this must be called if you want to use Navigation by pageKey).
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		/// <param name="pageType">Type of the page.</param>
		void RegisterPage(string pageKey, Type pageType);

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <param name="pageKey">The page key.</param>
		/// <param name="parameter">The parameter.</param>
		/// <param name="animated">if set to <c>true</c> [animated].</param>
		void NavigateTo(string pageKey, object parameter = null, bool animated = true);

		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <param name="pageType">Type of the page.</param>
		/// <param name="parameter">The parameter.</param>
		/// <param name="animated">if set to <c>true</c> [animated].</param>
		void NavigateTo(Type pageType, object parameter = null, bool animated = true);


		/// <summary>
		/// Navigates to.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parameter">The parameter.</param>
		/// <param name="animated">if set to <c>true</c> [animated].</param>
		void NavigateTo<T>(object parameter = null, bool animated = true) where T : class;

		/// <summary>
		/// Goes back.
		/// </summary>
		void GoBack();

		/// <summary>
		/// Goes forward.
		/// </summary>
		void GoForward();
	}
}