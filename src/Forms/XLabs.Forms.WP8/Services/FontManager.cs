namespace XLabs.Forms.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Windows.Media;

	using Xamarin.Forms;

	using XLabs.Forms.Extensions;
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
		public IEnumerable<string> AvailableFonts
		{
			get 
			{
				return Fonts.SystemTypefaces.Select(a =>
					{
						GlyphTypeface typeFace = null;
						a.TryGetGlyphTypeface(out typeFace);
						return typeFace;
					}).Where(a => a != null).Select(a => a.FontFileName);
				//throw new NotImplementedException(); 
			}
		}

		/// <summary>
		/// Gets height for the font.
		/// </summary>
		/// <param name="font">Font whose height is calculated.</param>
		/// <returns>Height of the font in inches.</returns>
		public double GetHeight(Font font)
		{
			double multiplier = (double)System.Windows.Application.Current.Host.Content.ScaleFactor / 100d;
			return multiplier * font.GetHeight() / this._display.Ydpi;
		}

		#endregion


	}
}
