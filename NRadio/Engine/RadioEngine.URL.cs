using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// The connection state.
		/// </summary>
		private ConnectionState connectionState;

		/// <summary>
		/// Stores the current URL.
		/// </summary>
		private String url;

		/// <summary>
		/// The stream urls concurrent stack.
		/// </summary>
		private readonly ConcurrentStack<String> urlsStack;

		/// <summary>
		/// The connection state.
		/// </summary>
		public ConnectionState ConnectionState
		{
			get => connectionState;
			private set
			{
				if (connectionState != value)
				{

					connectionState = value;

					ConnectionStateChanged?.Invoke(value);

				}
			}
		}

		/// <summary>
		/// Gets the current URL.
		/// </summary>
		public String URL => url;

		/// <summary>
		/// Occurs when connection state is changed.
		/// </summary>
		public event Action<ConnectionState> ConnectionStateChanged;

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

					ConnectionState = ConnectionState.Connection;

					Int32 handle = Bass.BASS_StreamCreateURL(currentURL, 0, BASSFlag.BASS_DEFAULT, null, IntPtr.Zero);

					this.handle.SetHandle(handle);

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