using System;

namespace XLabs.Platform.Extensions
{
	using CoreGraphics;

	using Foundation;
	using UIKit;

	/// <summary>
	/// Class StringExtensions.
	/// </summary>
	public static class StringExtensions
	{
		/// <summary>
		/// Gets the height of a string.
		/// </summary>
		/// <param name="text">The text.</param>
		/// <param name="font">The font.</param>
		/// <param name="width">The width.</param>
        /// <returns>nfloat.</returns>
		public static nfloat StringHeight(this string text, UIFont font, nfloat width)
		{
            return text.StringRect(font, width).Height;
		}

        /// <summary>
        /// Gets the rectangle of a string.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="font">The font.</param>
        /// <param name="width">The width.</param>
        /// <returns>CGRect.</returns>
	    public static CGRect StringRect(this string text, UIFont font, nfloat width)
	    {
            var nativeString = new NSString(text);

            return nativeString.GetBoundingRect(
                new CGSize(width, float.MaxValue),
                NSStringDrawingOptions.UsesLineFragmentOrigin,
                new UIStringAttributes { Font = font },
                null);
	    }
	}
}