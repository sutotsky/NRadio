using System;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{
		
		/// <summary>
		/// Contains flag which indicates whether playback is in progress.
		/// </summary>
		public Boolean IsPlaying { get; private set; }

		/// <summary>
		/// Starts playing.
		/// </summary>
		public void Play()
		{

			SetVolume(volume);

			IsPlaying = true;

		}

		/// <summary>
		/// Pause playing.
		/// </summary>
		public void Pause()
		{

			SetVolume(0);

			IsPlaying = false;

		}

	}
}