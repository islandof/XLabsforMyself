﻿namespace XLabs.Sample.Pages.Controls
{
	using Xamarin.Forms;

	using XLabs.Forms.Controls;

	/// <summary>
    /// Example page showing the ExtendedEntry control
    /// </summary>
    public partial class ExtendedEntryPage : ContentPage
    {
        /// <summary>
        /// Creates a new instance of the <see cref="ExtendedEntryPage"/> class
        /// </summary>
        public ExtendedEntryPage()
        {
            InitializeComponent();
			var entryFromCode = new ExtendedEntry() {
				Placeholder = "Aded from code, custom font",
				Font = Font.OfSize("Open 24 Display St", NamedSize.Medium)
			};

			StackLayout.Children.Add(entryFromCode);

            var swipeEntry = new ExtendedEntry()
            {
                    Placeholder = "Swipe me..."
            };

            swipeEntry.LeftSwipe += (s, e) => swipeEntry.Text = "Swiped left";

            swipeEntry.RightSwipe += (s, e) => swipeEntry.Text = "Swiped right";

            StackLayout.Children.Add(swipeEntry);
        }
    }
}
