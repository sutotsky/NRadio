using System;

namespace Dartware.NRadio.Meta
{
    /// <summary>
    /// Stores metadata that is supplied together with the audio stream.
    /// </summary>
    internal sealed class Metadata : IMetadata, IEquatable<Metadata>
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
		/// Stores the audio format.
		/// </summary>
		public Format Format { get; }

		/// <summary>
		/// Stores the current audio bitrate.
		/// </summary>
		public Int32 Bitrate { get; }

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
		/// <param name="format">Audio format.</param>
		/// <param name="bitrate">Audio bitrate.</param>
		internal Metadata(String songName, String artist, String title, Format format, Int32 bitrate)
		{
			SongName = songName;
			Artist = artist;
			Title = title;
			Format = format;
			Bitrate = bitrate;
		}

		/// <summary>
		/// Indicates whether the current <see cref="Metadata"/> instance is equal to another object of the same type.
		/// </summary>
		/// <param name="otherMetadata">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals(Metadata otherMetadata)
		{
			
			if (otherMetadata == null)
			{
				return false;
			}

			return otherMetadata.Artist == Artist && otherMetadata.Title == Title;

		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object other) => Equals(other as Metadata);

		/// <summary>
		/// Returns a string that represents the current <see cref="Metadata"/> instance.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => SongName;

		/// <summary>
		/// Serves as the default hash function.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override Int32 GetHashCode() => base.GetHashCode();

	}
}