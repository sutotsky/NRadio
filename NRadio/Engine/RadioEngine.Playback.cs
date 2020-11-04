using System;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{
		
		/// <summary>
		/// The playback status.
		/// </summary>
		public PlaybackStatus PlaybackStatus { get; private set; }

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