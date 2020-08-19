using System;
using System.Collections.Generic;
using System.Linq;
using Un4seen.Bass;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Contains a dictionary with equalizer channels, frequencies and values.
		/// </summary>
		private readonly IDictionary<Tuple<Int32, Int32>, Double> equalizer;

		/// <summary>
		/// Sets the equalizer values according to frequencies.
		/// </summary>
		/// <param name="equalizer">Dictionary with equalizer frequencies and values.</param>
		public void SetEqualizer(IDictionary<Int32, Double> equalizer)
		{

			if (equalizer == null)
			{
				throw new ArgumentNullException(nameof(equalizer), "Equalizer cannot be null.");
			}

			if (equalizer.Count == 0)
			{
				return;
			}

			foreach (KeyValuePair<Int32, Double> valuePair in equalizer)
			{
				SetEqualizerFrequency(valuePair.Key, valuePair.Value);
			}

		}

		/// <summary>
		/// Sets the equalizer value according to frequency.
		/// </summary>
		/// <param name="frequency"></param>
		/// <param name="value"></param>
		public void SetEqualizerFrequency(Int32 frequency, Double value)
		{

			BASS_DX8_PARAMEQ parameqDX8 = new BASS_DX8_PARAMEQ();

		}

		/// <summary>
		/// Gets the equalizer values according to frequencies.
		/// </summary>
		/// <returns>Dictionary with equalizer frequencies and values.</returns>
		public IDictionary<Int32, Double> GetEqualizer() => equalizer.ToDictionary(pair => pair.Key.Item2, pair => pair.Value);

	}
}