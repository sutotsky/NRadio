using System;

namespace Dartware.NRadio
{
	/// <summary>
	/// Defines the functionality for working with streaming audio, based on third-party URLs.
	/// </summary>
	public interface IRadioEngine
	{

		/// <summary>
		/// Gets or sets the stream URL.
		/// </summary>
		/// <exception cref="ArgumentNullException"></exception>
		String URL { get; set; }

		/// <summary>
		/// Gets or sets the volume level. Values in the range from 0 to 100 are allowed.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		Double Volume { get; set; }

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