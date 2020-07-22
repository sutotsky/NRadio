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
		/// Cancellation token source for metadata handle.
		/// </summary>
		private CancellationTokenSource metadataCancellationTokenSource;

		/// <summary>
		/// Gets the current metadata.
		/// </summary>
		public IMetadata Metadata { get; private set; }

		/// <summary>
		/// Occurs when metadata changed.
		/// </summary>
		public event Action<IMetadata> MetadataChanged;

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

					BASS_CHANNELINFO channelInfo = Bass.BASS_ChannelGetInfo(handle);
					Format format = Format.Unknown;

					if (channelInfo != null)
					{
						format = channelInfo.ctype.ToFormat();
					}

					TAG_INFO tagInfo = new TAG_INFO(url);
					String songName = null;
					String artist = null;
					String title = null;
					Int32 bitrate = 0;

					if (BassTags.BASS_TAG_GetFromURL(handle, tagInfo))
					{
						songName = tagInfo.ToString();
						artist = tagInfo.artist;
						title = tagInfo.title;
						bitrate = tagInfo.bitrate;
					}

					IMetadata metadata = new Metadata(songName, artist, title, format, bitrate);

					if (!metadata.Equals(Metadata))
					{

						Metadata = metadata;

						MetadataChanged?.Invoke(metadata);

					}

					Thread.Sleep(250);

				}
			});
		}

	}
}