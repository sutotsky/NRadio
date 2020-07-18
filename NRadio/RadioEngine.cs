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
		/// Gets or sets the volume level. Values in the range from 0 to 100 are allowed.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Double Volume
		{
			get
			{

				Single volume = 0f;

				if (Bass.BASS_ChannelGetAttribute(handle, BASSAttribute.BASS_ATTRIB_VOL, ref volume))
				{
					volume *= 100;
				}

				return volume;

			}
			set
			{

				if (value < 0 || value > 100)
				{
					throw new ArgumentOutOfRangeException(nameof(value), "The value must be between 0 and 100.");
				}

				Bass.BASS_ChannelSetAttribute(handle, BASSAttribute.BASS_ATTRIB_VOL, (Single) (value / 100));

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
		/// Sets the steam URL.
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