using System;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// The playback status.
		/// </summary>
		private PlaybackStatus playbackStatus;

		/// <summary>
		/// The playback status.
		/// </summary>
		public PlaybackStatus PlaybackStatus
		{
			get => playbackStatus;
			private set
			{
				if (playbackStatus != value)
				{

					playbackStatus = value;

					PlaybackStatusChanged?.Invoke(value);

				}
			}
		}

		/// <summary>
		/// Occurs when playback status changed.
		/// </summary>
		public event Action<PlaybackStatus> PlaybackStatusChanged;

		/// <summary>
		/// Starts playing.
		/// </summary>
		public void Play()
		{

			SetVolume(volume);

			PlaybackStatus = PlaybackStatus.Play;

		}

		/// <summary>
		/// Pause playing.
		/// </summary>
		public void Pause()
		{

			SetVolume(0);

			PlaybackStatus = PlaybackStatus.Pause;

		}

	}
}