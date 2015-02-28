﻿namespace XLabs.Platform.Device
{
	using System;

	using Microsoft.Phone.Info;

	/// <summary>
	/// Windows Phone Battery class.
	/// </summary>
	public partial class Battery
	{
		/// <summary>
		/// Gets the level.
		/// </summary>
		/// <value>The level in percentage 0-100.</value>
		public int Level
		{
			get
			{
				return Windows.Phone.Devices.Power.Battery.GetDefault().RemainingChargePercent;
			}
		}

		/// <summary>
		/// Gets a value indicating whether battery is charging
		/// </summary>
		/// <value><c>true</c> if charging; otherwise, <c>false</c>.</value>
		public bool Charging
		{
			get
			{
				return DeviceStatus.PowerSource == PowerSource.External;
			}
		}

		/// <summary>
		/// Called when [remaining charge percent changed].
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="o">The o.</param>
		private void OnRemainingChargePercentChanged(object sender, object o)
		{
			onLevelChange.Invoke(sender, Level);
		}

		/// <summary>
		/// Handles the <see cref="E:PowerSourceChanged" /> event.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="eventArgs">The <see cref="EventArgs"/> instance containing the event data.</param>
		private void OnPowerSourceChanged(object sender, EventArgs eventArgs)
		{
			onChargerStatusChanged.Invoke(sender, Charging);
		}

		#region partial implementations

		/// <summary>
		/// Starts the level monitoring.
		/// </summary>
		partial void StartLevelMonitoring()
		{
			Windows.Phone.Devices.Power.Battery.GetDefault().RemainingChargePercentChanged += OnRemainingChargePercentChanged;
		}

		/// <summary>
		/// Stops the level monitoring.
		/// </summary>
		partial void StopLevelMonitoring()
		{
			Windows.Phone.Devices.Power.Battery.GetDefault().RemainingChargePercentChanged -= OnRemainingChargePercentChanged;
		}

		/// <summary>
		/// Starts the charger monitoring.
		/// </summary>
		partial void StartChargerMonitoring()
		{
			DeviceStatus.PowerSourceChanged += OnPowerSourceChanged;
		}

		/// <summary>
		/// Stops the charger monitoring.
		/// </summary>
		partial void StopChargerMonitoring()
		{
			DeviceStatus.PowerSourceChanged -= OnPowerSourceChanged;
		}

		#endregion
	}
}