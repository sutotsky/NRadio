using System;
using System.Diagnostics.CodeAnalysis;

namespace Dartware.NRadio
{
	/// <summary>
	/// Stores metadata that is supplied together with the audio stream.
	/// </summary>
	public sealed class Metadata : IEquatable<Metadata>
	{

		/// <summary>
		/// Returns empty metadata instance.
		/// </summary>
		internal static Metadata Empty => new Metadata();

		/// <summary>
		/// Stores the name of the song. Consists of artist name and song title.
		/// </summary>
		public String SongName { get; }

		/// <summary>
		/// Stores the artist name. Is part of the song name (<see cref="SongName"/>).
		/// </summary>
		public String Artist { get; }

		/// <summary>
		/// Stores the song title. Is part of the song name (<see cref="SongName"/>).
		/// </summary>
		public String Title { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Metadata"/> class.
		/// </summary>
		private Metadata()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Metadata"/> class.
		/// </summary>
		/// <param name="songName">Name of the current song.</param>
		/// <param name="artist">Artist name.</param>
		/// <param name="title">Song title.</param>
		internal Metadata(String songName, String artist, String title)
		{
			SongName = songName;
			Artist = artist;
			Title = title;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="otherMetadata">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals([AllowNull] Metadata otherMetadata)
		{
			
			if (otherMetadata == null)
			{
				return false;
			}

			return otherMetadata.Artist == Artist && otherMetadata.Title == Title;

		}

	}
}