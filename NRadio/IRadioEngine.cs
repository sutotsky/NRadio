using System;
using System.Threading.Tasks;

namespace Dartware.NRadio
{
	/// <summary>
	/// Defines the functionality for working with streaming audio, based on third-party URLs.
	/// </summary>
	public interface IRadioEngine
	{
		
		/// <summary>
		/// Gets or sets the volume level. Values in the range from 0 to 100 are allowed.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		Double Volume { get; set; }

		/// <summary>
		/// Gets the current metadata.
		/// </summary>
		IMetadata Metadata { get; }

		/// <summary>
		/// Occurs when connection is started.
		/// </summary>
		event Action ConnectionStarted;

		/// <summary>
		/// Occurs when connection is ended.
		/// </summary>
		event Action ConnectionEnded;

		/// <summary>
		/// Occurs when buffering is started.
		/// </summary>
		event Action BufferingStarted;

		/// <summary>
		/// Occurs when buffering progress is changed.
		/// </summary>
		event Action<Int64> BufferingProgressChanged;

		/// <summary>
		/// Occurs when buffering is ended.
		/// </summary>
		event Action BufferingEnded;

		/// <summary>
		/// Occurs when metadata changed.
		/// </summary>
		event Action<IMetadata> MetadataChanged;

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		void SetURL(String url);

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		Task SetURLAsync(String url);

		/// <summary>
		/// Returns current URL of the stream.
		/// </summary>
		/// <returns>URL of the stream.</returns>
		String GetURL();

		/// <summary>
		/// Starts playing.
		/// </summary>
		void Play();

		/// <summary>
		/// Pause playing.
		/// </summary>
		void Pause();

	}
}