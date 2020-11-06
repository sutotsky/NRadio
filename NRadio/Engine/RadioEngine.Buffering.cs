using System;
using System.Threading;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Cancellation token source for buffering handle.
		/// </summary>
		private CancellationTokenSource bufferingCancellationTokenSource;

		/// <summary>
		/// Occurs when buffering progress is changed.
		/// </summary>
		public event Action<Int64> BufferingProgressChanged;

		/// <summary>
		/// Starts tracking buffering progress.
		/// </summary>
		/// <param name="cancellationToken">Cancellation handling token.</param>
		private void StartBuferingHandle(CancellationToken cancellationToken)
		{
			Task.Run(() =>
			{

				ConnectionState = ConnectionState.Buffering;

				while (Bass.BASS_ChannelIsActive(handle) != BASSActive.BASS_ACTIVE_PLAYING && !cancellationToken.IsCancellationRequested)
				{

					Int64 filePosition = Bass.BASS_StreamGetFilePosition(handle, BASSStreamFilePosition.BASS_FILEPOS_BUFFERING);
					Int64 bufferingPercentage = 100 - filePosition;

					BufferingProgressChanged?.Invoke(bufferingPercentage);

					if (bufferingPercentage < 0 || bufferingPercentage >= 100)
					{

						ConnectionState = ConnectionState.None;

						return;

					}

					Thread.Sleep(50);

				}

				ConnectionState = ConnectionState.None;

			});
		}

	}
}