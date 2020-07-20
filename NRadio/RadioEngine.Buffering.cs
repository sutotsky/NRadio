using System;
using System.Threading;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Cancellation token source for buffering handle.
		/// </summary>
		private CancellationTokenSource bufferingCancellationTokenSource;

		/// <summary>
		/// Occurs when buffering is started.
		/// </summary>
		public event Action BufferingStarted;

		/// <summary>
		/// Occurs when buffering progress is changed.
		/// </summary>
		public event Action<Int64> BufferingProgressChanged;

		/// <summary>
		/// Occurs when buffering is ended.
		/// </summary>
		public event Action BufferingEnded;

		/// <summary>
		/// Starts tracking buffering progress.
		/// </summary>
		private void StartBuferingHandle(CancellationToken cancellationToken)
		{

			BufferingStarted?.Invoke();

			while (Bass.BASS_ChannelIsActive(handle) != BASSActive.BASS_ACTIVE_PLAYING && !cancellationToken.IsCancellationRequested)
			{

				Int64 filePosition = Bass.BASS_StreamGetFilePosition(handle, BASSStreamFilePosition.BASS_FILEPOS_BUFFERING);
				Int64 bufferingPercentage = 100 - filePosition;

				BufferingProgressChanged?.Invoke(bufferingPercentage);

				if (bufferingPercentage < 0 || bufferingPercentage >= 100)
				{

					BufferingEnded?.Invoke();
					
					return;

				}

				Thread.Sleep(50);

			}

			BufferingEnded?.Invoke();

		}

	}
}