using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Stores the current URL.
		/// </summary>
		private String url;

		/// <summary>
		/// The stream urls concurrent stack.
		/// </summary>
		private readonly ConcurrentStack<String> urlsStack;

		/// <summary>
		/// Gets the current URL.
		/// </summary>
		public String URL => url;

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

					Int32 handle = Bass.BASS_StreamCreateURL(currentURL, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

					this.handle.SetHandle(handle);

					ConnectionEnded?.Invoke();

					SetVolume(0);
					UpdateFX();
					Bass.BASS_ChannelPlay(handle, false);

					StartMetadataHandle(metadataCancellationTokenSource.Token);
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

	}
}