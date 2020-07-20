using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// The stream urls concurrent stack.
		/// </summary>
		private readonly ConcurrentStack<String> urlsStack;

		/// <summary>
		/// Contains the current stream URL.
		/// </summary>
		private String url;
		
		/// <summary>
		/// Occurs when connection is started.
		/// </summary>
		public event Action ConnectionStarted;

		/// <summary>
		/// Occurs when connection is ended.
		/// </summary>
		public event Action ConnectionEnded;

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

			urlsStack.Push(url);
			bufferingCancellationTokenSource?.Cancel();

			lock (urlsStack)
			{
				if (urlsStack.TryPeek(out String currentURL))
				{

					urlsStack.Clear();
					Free();
					Init();

					ConnectionStarted?.Invoke();

					handle = Bass.BASS_StreamCreateURL(currentURL, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

					ConnectionEnded?.Invoke();
					StartBuferingHandle(bufferingCancellationTokenSource.Token);

				}
			}

		}

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		public async Task SetURLAsync(String url)
		{
			await Task.Run(() => SetURL(url));
		}

		/// <summary>
		/// Returns current URL of the stream.
		/// </summary>
		/// <returns>URL of the stream.</returns>
		public String GetURL() => url;

	}
}