using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace XLabs.Forms.Services
{
	using System;
	using System.Collections.Generic;

	using XLabs.Platform.Device;

	/// <summary>
	/// Class FontManager.
	/// </summary>
	public partial class FontManager : IFontManager
	{
		/// <summary>
		/// The _display
		/// </summary>
		private readonly IDisplay _display;

		/// <summary>
		/// Initializes a new instance of the <see cref="FontManager"/> class.
		/// </summary>
		/// <param name="display">The display.</param>
		public FontManager(IDisplay display)
		{
			this._display = display;
		}

		#region IFontManager Members

		/// <summary>
		/// Gets all available system fonts.
		/// </summary>
		/// <value>The available fonts.</value>
		/// <exception cref="System.NotImplementedException"></exception>
		public IEnumerable<string> AvailableFonts
		{
			get { throw new NotImplementedException(); }
		}

		/// <summary>
		/// Gets height for the font.
		/// </summary>
		/// <param name="font">Font whose height is calculated.</param>
		/// <returns>Height of the font in inches.</returns>
		public double GetHeight(Font font)
		{
			var scaled = font.ToScaledPixel();
			return scaled *  Display.Metrics.Density / _display.Ydpi;
		}

		#endregion
	}
}
