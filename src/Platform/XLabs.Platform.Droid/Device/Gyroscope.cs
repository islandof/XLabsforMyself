namespace XLabs.Platform.Device
{
	using System;

	using Android.App;
	using Android.Content;
	using Android.Hardware;

	using Object = Java.Lang.Object;

	/// <summary>
	/// Class Gyroscope.
	/// </summary>
	public partial class Gyroscope : Object, ISensorEventListener
	{
		/// <summary>
		/// The _delay
		/// </summary>
		private SensorDelay _delay;

		/// <summary>
		/// The _gyroscope
		/// </summary>
		private Sensor _gyroscope;

		/// <summary>
		/// The _sensor manager
		/// </summary>
		private SensorManager _sensorManager;

		/// <summary>
		/// Gets a value indicating whether this instance is supported.
		/// </summary>
		/// <value><c>true</c> if this instance is supported; otherwise, <c>false</c>.</value>
		public static bool IsSupported
		{
			get
			{
				var sensorManager = Application.Context.GetSystemService(Context.SensorService) as SensorManager;
				return sensorManager != null && sensorManager.GetDefaultSensor(SensorType.Gyroscope) != null;
			}
		}

		/// <summary>
		/// Gets or sets the interval.
		/// </summary>
		/// <value>The interval.</value>
		public AccelerometerInterval Interval
		{
			get
			{
				switch (_delay)
				{
					case SensorDelay.Fastest:
						return AccelerometerInterval.Fastest;
					case SensorDelay.Game:
						return AccelerometerInterval.Game;
					case SensorDelay.Normal:
						return AccelerometerInterval.Normal;
					default:
						return AccelerometerInterval.Ui;
				}
			}
			set
			{
				switch (value)
				{
					case AccelerometerInterval.Fastest:
						_delay = SensorDelay.Fastest;
						break;
					case AccelerometerInterval.Game:
						_delay = SensorDelay.Game;
						break;
					case AccelerometerInterval.Normal:
						_delay = SensorDelay.Normal;
						break;
					case AccelerometerInterval.Ui:
						_delay = SensorDelay.Ui;
						break;
				}
			}
		}

		/// <summary>
		/// Starts this instance.
		/// </summary>
		partial void Start()
		{
			_sensorManager = Application.Context.GetSystemService(Context.SensorService) as SensorManager;

			_gyroscope = _sensorManager.GetDefaultSensor(SensorType.Gyroscope);

			_sensorManager.RegisterListener(this, _gyroscope, _delay);
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		partial void Stop()
		{
			_sensorManager.UnregisterListener(this);
			_sensorManager = null;
			_gyroscope = null;
		}

		#region ISensorEventListener Members

		/// <summary>
		/// Called when the accuracy of a sensor has changed.
		/// </summary>
		/// <param name="sensor">To be added.</param>
		/// <param name="accuracy">The new accuracy of this sensor</param>
		/// <exception cref="System.NotImplementedException"></exception>
		/// <since version="Added in API level 3" />
		/// <remarks><para tool="javadoc-to-mdoc">Called when the accuracy of a sensor has changed.
		/// </para>
		/// <para tool="javadoc-to-mdoc">See <c><see cref="T:Android.Hardware.SensorManager" /></c>
		/// for details.</para>
		/// <para tool="javadoc-to-mdoc">
		///   <format type="text/html">
		///     <a href="http://developer.android.com/reference/android/hardware/SensorEventListener.html#onAccuracyChanged(android.hardware.Sensor, int)" target="_blank">[Android Documentation]</a>
		///   </format>
		/// </para></remarks>
		public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Called when sensor values have changed.
		/// </summary>
		/// <param name="e">the <c><see cref="T:Android.Hardware.SensorEvent" /></c>.</param>
		/// <since version="Added in API level 3" />
		/// <remarks><para tool="javadoc-to-mdoc">Called when sensor values have changed.
		/// </para>
		/// <para tool="javadoc-to-mdoc">See <c><see cref="T:Android.Hardware.SensorManager" /></c>
		/// for details on possible sensor types.
		/// </para>
		/// <para tool="javadoc-to-mdoc">See also <c><see cref="T:Android.Hardware.SensorEvent" /></c>.
		/// </para>
		/// <para tool="javadoc-to-mdoc">
		///   <format type="text/html">
		///     <b>NOTE:</b>
		///   </format> The application doesn't own the
		/// <c><see cref="T:Android.Hardware.SensorEvent" /></c>
		/// object passed as a parameter and therefore cannot hold on to it.
		/// The object may be part of an internal pool and may be reused by
		/// the framework.</para>
		/// <para tool="javadoc-to-mdoc">
		///   <format type="text/html">
		///     <a href="http://developer.android.com/reference/android/hardware/SensorEventListener.html#onSensorChanged(android.hardware.SensorEvent)" target="_blank">[Android Documentation]</a>
		///   </format>
		/// </para></remarks>
		public void OnSensorChanged(SensorEvent e)
		{
			if (e.Sensor.Type != SensorType.Gyroscope)
			{
				return;
			}

			this.LatestReading = new Vector3(e.Values[0], e.Values[1], e.Values[2]);

			this.readingAvailable.Invoke(this, this.LatestReading);
		}

		#endregion
	}
}