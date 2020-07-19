using System;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{
		
		/// <summary>
		/// Contains flag which indicates whether playback is in progress.
		/// </summary>
		private Boolean isPlaying;

		/// <summary>
		/// Starts playing.
		/// </summary>
		public void Play()
		{

			SetVolume(volume);
			Bass.BASS_ChannelPlay(handle, false);

			isPlaying = true;

		}

		/// <summary>
		/// Pause playing.
		/// </summary>
		public void Pause()
		{

			SetVolume(0);

			isPlaying = false;

		}

	}
}