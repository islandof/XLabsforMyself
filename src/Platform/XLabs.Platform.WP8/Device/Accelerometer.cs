namespace XLabs.Platform.Device
{
	using System;

	using Microsoft.Devices.Sensors;

	/// <summary>
	/// Class Accelerometer.
	/// </summary>
	public partial class Accelerometer
	{
		/// <summary>
		/// The _accelerometer
		/// </summary>
		private Microsoft.Devices.Sensors.Accelerometer _accelerometer;

		/// <summary>
		/// Gets or sets the interval.
		/// </summary>
		/// <value>The interval.</value>
		public AccelerometerInterval Interval { get; set; }

		/// <summary>
		/// Starts this instance.
		/// </summary>
		partial void Start()
		{
			_accelerometer = new Microsoft.Devices.Sensors.Accelerometer
				                 {
					                 TimeBetweenUpdates =
						                 TimeSpan.FromMilliseconds((long)Interval)
				                 };

			_accelerometer.CurrentValueChanged += AccelerometerOnCurrentValueChanged;
			_accelerometer.Start();
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		partial void Stop()
		{
			if (_accelerometer != null)
			{
				_accelerometer.CurrentValueChanged -= AccelerometerOnCurrentValueChanged;
				_accelerometer.Stop();
				_accelerometer = null;
			}
		}

		/// <summary>
		/// Accelerometers the on current value changed.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="sensorReadingEventArgs">The sensor reading event arguments.</param>
		private void AccelerometerOnCurrentValueChanged(
			object sender,
			SensorReadingEventArgs<AccelerometerReading> sensorReadingEventArgs)
		{
			LatestReading = sensorReadingEventArgs.SensorReading.Acceleration.AsVector3();
			readingAvailable.Invoke(sender, LatestReading);
		}
	}
}