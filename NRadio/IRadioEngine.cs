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
		String URL { get; set; }

		/// <summary>
		/// Starts playing.
		/// </summary>
		void Play();

	}
}