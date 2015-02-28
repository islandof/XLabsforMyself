﻿namespace XLabs.Platform.Services
{
	using System;
	using System.IO;
	using System.Threading.Tasks;

	using Android.App;
	using Android.Content.Res;
	using Android.Media;

	using XLabs.Platform.Services.Sound;

	/// <summary>
	/// Class SoundService.
	/// </summary>
	public class SoundService : ISoundService
	{
		/// <summary>
		/// The _is player prepared
		/// </summary>
		private bool _isPlayerPrepared;

		/// <summary>
		/// The _is scrubbing
		/// </summary>
		private bool _isScrubbing;

		/// <summary>
		/// The _player
		/// </summary>
		private MediaPlayer _player;

		/// <summary>
		/// Starts the player asynchronous from assets folder.
		/// </summary>
		/// <param name="fp">The fp.</param>
		/// <returns>Task.</returns>
		/// <exception cref="FileNotFoundException">Make sure you set your file in the Assets folder</exception>
		private async Task StartPlayerAsyncFromAssetsFolder(AssetFileDescriptor fp)
		{
			try
			{
				if (_player == null)
				{
					_player = new MediaPlayer();
				}
				else
				{
					_player.Reset();
				}

				if (fp == null)
				{
					throw new FileNotFoundException("Make sure you set your file in the Assets folder");
				}

				await _player.SetDataSourceAsync(fp.FileDescriptor);
				_player.Prepared += (s, e) =>
					{
						_player.SetVolume(0, 0);
						_isPlayerPrepared = true;
					};
				_player.Prepare();
			}
			catch (Exception ex)
			{
				Console.Out.WriteLine(ex.StackTrace);
			}
		}

		#region ISoundService implementation

		/// <summary>
		/// Occurs when [sound file finished].
		/// </summary>
		public event EventHandler SoundFileFinished;

		/// <summary>
		/// Plays the asynchronous.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <param name="extension">The extension.</param>
		/// <returns>Task&lt;SoundFile&gt;.</returns>
		public Task<SoundFile> PlayAsync(string filename, string extension = null)
		{
			return Task.Run<SoundFile>(
				async () =>
					{
						if (_player == null || string.Compare(filename, CurrentFile.Filename) > 0)
						{
							await SetMediaAsync(filename);
						}
						_player.Start();
						return CurrentFile;
					});
		}

		/// <summary>
		/// set media as an asynchronous operation.
		/// </summary>
		/// <param name="filename">The filename.</param>
		/// <returns>Task&lt;SoundFile&gt;.</returns>
		public async Task<SoundFile> SetMediaAsync(string filename)
		{
			CurrentFile = new SoundFile();
			CurrentFile.Filename = filename;
			await StartPlayerAsyncFromAssetsFolder(Application.Context.Assets.OpenFd(filename));
			CurrentFile.Duration = TimeSpan.FromSeconds(_player.Duration);
			return CurrentFile;
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
							_player.SeekTo(TimeSpan.FromSeconds(position).Milliseconds);
							_isScrubbing = false;
						}
					});
		}

		/// <summary>
		/// Plays this instance.
		/// </summary>
		public void Play()
		{
			if ((_player != null))
			{
				if (!_player.IsPlaying)
				{
					_player.Start();
				}
			}
		}

		/// <summary>
		/// Stops this instance.
		/// </summary>
		public void Stop()
		{
			if ((_player != null))
			{
				if (_player.IsPlaying)
				{
					_player.Stop();
				}
				_player.Release();
				_player = null;
			}
		}

		/// <summary>
		/// Pauses this instance.
		/// </summary>
		public void Pause()
		{
			if ((_player != null))
			{
				if (_player.IsPlaying)
				{
					_player.Pause();
				}
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
				return 0.5;
			}
			set
			{
				if (_player != null && _isPlayerPrepared)
				{
					_player.SetVolume((float)value, (float)value);
				}
			}
		}

		/// <summary>
		/// The _current time
		/// </summary>
		private double _currentTime;

		/// <summary>
		/// Gets the current time.
		/// </summary>
		/// <value>The current time.</value>
		public double CurrentTime
		{
			get
			{
				if (_player == null)
				{
					return 0;
				}
				return TimeSpan.FromMilliseconds(_player.CurrentPosition).TotalSeconds;
			}
			set
			{
				_currentTime = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether this instance is playing.
		/// </summary>
		/// <value><c>true</c> if this instance is playing; otherwise, <c>false</c>.</value>
		public bool IsPlaying
		{
			get
			{
				return _player.IsPlaying;
			}
		}

		/// <summary>
		/// Gets the current file.
		/// </summary>
		/// <value>The current file.</value>
		public SoundFile CurrentFile { get; private set; }

		#endregion
	}
}