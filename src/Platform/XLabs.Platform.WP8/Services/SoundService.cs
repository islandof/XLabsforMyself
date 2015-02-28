﻿namespace XLabs.Platform.Services
{
	using System;
	using System.Threading.Tasks;
	using System.Windows;
	using System.Windows.Controls;

	using XLabs.Platform.Services.Sound;

	/// <summary>
	/// SoundService implementation on the Windows Phone platform
	/// Nees a GlobalMEdiaElement instance on the App resources dictionary
	/// </summary>
	public class SoundService : ISoundService
	{
		/// <summary>
		/// The _is scrubbing
		/// </summary>
		private bool _isScrubbing;

		/// <summary>
		/// The _TCS set media
		/// </summary>
		private TaskCompletionSource<SoundFile> _tcsSetMedia;

		/// <summary>
		/// Initializes a new instance of the <see cref="SoundService"/> class.
		/// </summary>
		public SoundService()
		{
			IsPlaying = false;
			CurrentFile = null;
		}

		/// <summary>
		/// Gets the global media element.
		/// </summary>
		/// <value>The global media element.</value>
		/// <exception cref="ArgumentNullException">GlobalMedia is missing</exception>
		public static MediaElement GlobalMediaElement
		{
			get
			{
				if (Application.Current.Resources.Contains("GlobalMedia"))
				{
					return Application.Current.Resources["GlobalMedia"] as MediaElement;
				}
				throw new ArgumentNullException("GlobalMedia is missing");
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is playing.
		/// </summary>
		/// <value><c>true</c> if this instance is playing; otherwise, <c>false</c>.</value>
		public bool IsPlaying { get; private set; }

		/// <summary>
		/// Gets the current time.
		/// </summary>
		/// <value>The current time.</value>
		public double CurrentTime
		{
			get
			{
				if (GlobalMediaElement == null)
				{
					return 0;
				}
				return GlobalMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
			}
		}

		/// <summary>
		/// Gets or sets the volume.
		/// </summary>
		/// <value>The volume.</value>
		public double Volume
		{
			get
			{
				if (GlobalMediaElement == null)
				{
					return 0;
				}
				return GlobalMediaElement.Volume;
			}
			set
			{
				if (GlobalMediaElement != null)
				{
					GlobalMediaElement.Volume = value;
				}
			}
		}

		/// <summary>
		/// Gets the current file.
		/// </summary>
		/// <value>The current file.</value>
		public SoundFile CurrentFile { get; private set; }

		/// <summary>
		/// Plays this instance.
		/// </summary>
		public void Play()
		{
			if (GlobalMediaElement != null && !IsPlaying)
			{
				GlobalMediaElement.Play();
				IsPlaying = true;
			}
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		public void Stop()
		{
			if (GlobalMediaElement != null)
			{
				GlobalMediaElement.Stop();
				IsPlaying = false;
				//   player.du = 0.0;
			}
		}

		/// <summary>
		/// Pauses this instance.
		/// </summary>
		public void Pause()
		{
			if (GlobalMediaElement != null && IsPlaying)
			{
				GlobalMediaElement.Pause();
				IsPlaying = false;
			}
		}

		/// <summary>
		/// Occurs when [sound file finished].
		/// </summary>
		public event EventHandler SoundFileFinished;

		/// <summary>
		/// Raises the <see cref="E:FileFinished" /> event.
		/// </summary>
		/// <param name="e">The <see cref="SoundFinishedEventArgs" /> instance containing the event data.</param>
		protected virtual void OnFileFinished(SoundFinishedEventArgs e)
		{
			if (SoundFileFinished != null)
			{
				SoundFileFinished(this, e);
			}
		}

		/// <summary>
		/// Plays the asynchronous.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="extension">The extension.</param>
		/// <returns>Task&lt;SoundFile&gt;.</returns>
		public async Task<SoundFile> PlayAsync(string filename, string extension = null)
		{
			if (GlobalMediaElement != null || string.Compare(filename, CurrentFile.Filename) > 0)
			{
				await SetMediaAsync(filename);

				GlobalMediaElement.Play();

				IsPlaying = true;
				return CurrentFile;
			}
			return null;
		}

		/// <summary>
		/// Sets the media asynchronous.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns>Task&lt;SoundFile&gt;.</returns>
		public Task<SoundFile> SetMediaAsync(string filename)
		{
			_tcsSetMedia = new TaskCompletionSource<SoundFile>();

			CurrentFile = new SoundFile {Filename = filename};

			return Task.Run(() =>
			{
				if (Application.GetResourceStream(new Uri(CurrentFile.Filename, UriKind.Relative)) == null)
				{
					MessageBox.Show("File doesn't exist!");
				}

				//TODO: need to clean this events
				GlobalMediaElement.MediaEnded += GlobalMediaElementMediaEnded;
				GlobalMediaElement.MediaOpened += GlobalMediaElementMediaOpened;

				GlobalMediaElement.Source = new Uri(CurrentFile.Filename, UriKind.Relative);

				return _tcsSetMedia.Task;
			});
		}

		/// <summary>
		/// Globals the media element media opened.
		/// </summary>
		/// <param name="sender">The sender.</param>
		/// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
		private void GlobalMediaElementMediaOpened(object sender, RoutedEventArgs e)
		{
			if (_tcsSetMedia != null)
			{
				CurrentFile.Duration = TimeSpan.FromSeconds(GlobalMediaElement.NaturalDuration.TimeSpan.TotalSeconds);
				_tcsSetMedia.SetResult(CurrentFile);
			}
		}

		/// <summary>
		/// Handles the MediaEnded event of the player control.
		/// </summary>
		/// <param name="sender">The source of the event.</param>
		/// <param name="e">The <see cref="System.Windows.RoutedEventArgs" /> instance containing the event data.</param>
		private void GlobalMediaElementMediaEnded(object sender, RoutedEventArgs e)
		{
			OnFileFinished(new SoundFinishedEventArgs(CurrentFile));
		}

		/// <summary>
		/// Goes to asynchronous.
		/// </summary>
		/// <param name="position">The position.</param>
		/// <returns>Task.</returns>
		public Task GoToAsync(double position)
		{
			return Task.Run(
				() =>
					{
						if (!_isScrubbing)
						{
							_isScrubbing = true;
							//    player.CurrentTime = position;
							_isScrubbing = false;
						}
					});
		}
	}
}