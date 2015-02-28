﻿using System;
using Xamarin.Forms;

namespace XLabs.Forms.Controls
{
	/// <summary>
	/// Class CheckboxCell.
	/// </summary>
	public class CheckboxCell : ExtendedTextCell
	{
		/// <summary>
		/// The checked changed
		/// </summary>
		public EventHandler<EventArgs<bool>> CheckedChanged;

		/// <summary>
		/// The checked property
		/// </summary>
		public static readonly BindableProperty CheckedProperty = BindableProperty.Create<CheckboxCell, bool> (p => p.Checked, default(bool));
		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="CheckboxCell"/> is checked.
		/// </summary>
		/// <value><c>true</c> if checked; otherwise, <c>false</c>.</value>
		public bool Checked {
			get { return (bool)GetValue (CheckedProperty); }
			set { SetValue (CheckedProperty, value); }
		}

		/// <summary>
		/// The turn on only
		/// </summary>
		readonly bool _turnOnOnly;

		/// <summary>
		/// Initializes a new instance of the <see cref="CheckboxCell"/> class.
		/// </summary>
		/// <param name="turnOnOnly">if set to <c>true</c> [turn on only].</param>
		public CheckboxCell (bool turnOnOnly = false)
		{
			this._turnOnOnly = turnOnOnly;
			Tapped += HandleTapped;
			BackgroundColor = Color.White;
		}

		/// <summary>
		/// Handles the tapped.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
		void HandleTapped (object sender, EventArgs e)
		{
			if (_turnOnOnly) {
				if (!Checked) {
					Checked = true;
					RaiseCheckedChanged (Checked);
				}
			} else {
				Checked = !Checked;
				RaiseCheckedChanged (Checked);
			}
		}

		/// <summary>
		/// Raises the checked changed.
		/// </summary>
		/// <param name="val">if set to <c>true</c> [value].</param>
		void RaiseCheckedChanged(bool val)
		{
			if (CheckedChanged != null)
				CheckedChanged (this, new EventArgs<bool> (val));
		}
	}
}

