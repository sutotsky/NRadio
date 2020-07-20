using System.Threading;
using System.Threading.Tasks;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Cancellation token source for metadata handle.
		/// </summary>
		private CancellationTokenSource metadataCancellationTokenSource;

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
					Thread.Sleep(250);
				}
			});
		}

	}
}