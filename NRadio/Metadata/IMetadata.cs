using System;

namespace Dartware.NRadio.Meta
{
	/// <summary>
	/// Defines functionality for stores metadata that is supplied together with the audio stream.
	/// </summary>
	public interface IMetadata
	{

		/// <summary>
		/// Stores the name of the song. Consists of artist name and song title.
		/// </summary>
		String SongName { get; }

		/// <summary>
		/// Stores the artist name. Is part of the song name (<see cref="SongName"/>).
		/// </summary>
		String Artist { get; }

		/// <summary>
		/// Stores the song title. Is part of the song name (<see cref="SongName"/>).
		/// </summary>
		String Title { get; }

		/// <summary>
		/// Stores the audio format.
		/// </summary>
		Format Format { get; }

		/// <summary>
		/// Stores the current audio bitrate.
		/// </summary>
		Int32 Bitrate { get; }

	}
}