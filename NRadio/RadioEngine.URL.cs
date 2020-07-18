using System;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

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

				if (String.IsNullOrEmpty(url))
				{
					throw new ArgumentNullException(nameof(url), "URL cannot be null or empty.");
				}

				Free();
				Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

				handle = Bass.BASS_StreamCreateURL(url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

			}
		}

	}
}