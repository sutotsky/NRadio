using System;
using System.Collections.Generic;

namespace Dartware.NRadio.FX
{
	/// <summary>
	/// Represents the equalizer effect.
	/// </summary>
	public interface IEqualizer
	{

		/// <summary>
		/// Sets the equalizer values according to frequencies.
		/// </summary>
		/// <param name="equalizer">Dictionary with equalizer frequencies and values.</param>
		/// <exception cref="ArgumentNullException"></exception>
		void SetEqualizer(IDictionary<Int32, Double> equalizer);

		/// <summary>
		/// Sets the equalizer value according to frequency.
		/// </summary>
		/// <param name="frequency"></param>
		/// <param name="value"></param>
		void SetEqualizerFrequency(Int32 frequency, Double value);

		/// <summary>
		/// Gets the equalizer values according to frequencies.
		/// </summary>
		/// <returns>Dictionary with equalizer frequencies and values.</returns>
		IDictionary<Int32, Double> GetEqualizer();

	}
}