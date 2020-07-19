using System;
using System.Threading.Tasks;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Contains the current stream URL.
		/// </summary>
		private String url;

		/// <summary>
		/// Gets the stream URL.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		public String URL => url;

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		public void SetURL(String url)
		{

			if (String.IsNullOrEmpty(url))
			{
				throw new ArgumentNullException(nameof(url), "URL cannot be null or empty.");
			}

			this.url = url;

			Free();
			Init();

			handle = Bass.BASS_StreamCreateURL(url, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

		}

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		public async Task SetURLAsync(String url)
		{
			await Task.Run(() => SetURL(url));
		}

	}
}