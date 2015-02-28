﻿namespace XLabs.Sample.Pages.Controls
{
	using System.Globalization;

	using Xamarin.Forms;

	using XLabs.Forms.Controls;

	/// <summary>
	/// Class ExtendedSliderPage.
	/// </summary>
	public class ExtendedSliderPage : ContentPage
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ExtendedSliderPage" /> class.
		/// </summary>
		public ExtendedSliderPage()
		{
			var sliderMain = new ExtendedSlider
			{
				Minimum = 0.0f,
				Maximum = 5.0f,
				Value = 0.0f,
				StepValue = 1.0f,
				HorizontalOptions = LayoutOptions.FillAndExpand,
			};

			var labelCurrentValue = new Label
			{
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				BindingContext = sliderMain,
			};

			labelCurrentValue.SetBinding(Label.TextProperty,
											new Binding("Value", BindingMode.OneWay,
												null, null, "Current Value: {0}"));

			var grid = new Grid
			{
				// BackgroundColor = Color.Black,
				Padding = 10,
				RowDefinitions =
				{
					new RowDefinition {Height = GridLength.Auto},
				},
				ColumnDefinitions =
				{
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
				},
			};

			for (var i = 0; i < 6; i++)
			{
				var label = new Label
				{
					Text = i.ToString(CultureInfo.InvariantCulture),
				};

				var tapValue = i; // Prevent modified closure

				label.GestureRecognizers.Add(new TapGestureRecognizer
				{
					Command = new Command(() => { sliderMain.Value = tapValue; }),
					NumberOfTapsRequired = 1
				});

				grid.Children.Add(label, i, 0);
			}

			Content = new StackLayout
			{
				Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 10),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = { grid, sliderMain, labelCurrentValue },
			};
		}
	}
}
