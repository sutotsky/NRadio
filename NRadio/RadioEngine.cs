using System;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	/// <summary>
	/// Radio-engine implementation based on the cross-platform library bass.dll. Requires: bass.dll - Bass Audio Library - available <see href="http://www.un4seen.com">here</see>.
	/// </summary>
	internal sealed partial class RadioEngine : IRadioEngine
	{

		/// <summary>
		/// The channel handle. A HSTREAM, HMUSIC, or HRECORD.
		/// </summary>
		private Int32 handle;

		/// <summary>
		/// Stream URL.
		/// </summary>
		private String url;

		/// <summary>
		/// Gets or sets the stream URL.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		public String URL
		{
			get => url;
			set
			{
				
				url = value;

				SetURL(url);

			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="RadioEngine"/> class.
		/// </summary>
		internal RadioEngine()
		{
			Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);
		}

		/// <summary>
		/// Starts playing.
		/// </summary>
		public void Play()
		{
			Bass.BASS_ChannelPlay(handle, false);
		}

		/// <summary>
		/// Set steam URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		/// <exception cref="ArgumentNullException"></exception>
		private void SetURL(String url)
		{

			if (String.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException(nameof(url), "URL cannot be null.");
			}

			handle = Bass.BASS_StreamCreateURL(url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

		}

	}
}