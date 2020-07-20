using System;
using System.Threading;
using System.Threading.Tasks;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Tags;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Stores current metadata.
		/// </summary>
		private Metadata metadata;

		/// <summary>
		/// Cancellation token source for metadata handle.
		/// </summary>
		private CancellationTokenSource metadataCancellationTokenSource;

		/// <summary>
		/// Occurs when metadata changed.
		/// </summary>
		public event Action<Metadata> MetadataChanged;

		/// <summary>
		/// Starts tracking metadata changes.
		/// </summary>
		/// <param name="cancellationToken">Cancellation handling token.</param>
		private void StartMetadataHandle(CancellationToken cancellationToken)
		{
			Task.Run(() =>
			{
				while (!cancellationToken.IsCancellationRequested)
				{

					TAG_INFO tagInfo = new TAG_INFO(url);
					BASS_CHANNELINFO channelinfo = Bass.BASS_ChannelGetInfo(handle);

					if (BassTags.BASS_TAG_GetFromURL(handle, tagInfo))
					{

						Metadata metadata = new Metadata(tagInfo.ToString(), tagInfo.artist, tagInfo.title);

						if (!metadata.Equals(this.metadata))
						{

							this.metadata = metadata;

							MetadataChanged?.Invoke(metadata);

						}

					}

					Thread.Sleep(250);

				}
			});
		}

	}
}