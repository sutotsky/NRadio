using System;
using System.Collections.Generic;
using System.Linq;
using Dartware.NRadio.Core;

namespace Dartware.NRadio.FX
{
	/// <summary>
	/// Equalizer effect - an effect that adjusts the timbre of an audio signal by changing the amplitude of its frequency components.
	/// </summary>
	internal sealed class Equalizer : IEqualizer
	{

		/// <summary>
		/// The channel handle.
		/// </summary>
		private readonly Handle handle;

		/// <summary>
		/// Contains a dictionary with equalizer channels, frequencies and values.
		/// </summary>
		private readonly IDictionary<Tuple<Int32, Int32>, Double> equalizer;

		/// <summary>
		/// Initializes a new instance of the <see cref="Equalizer"/> class.
		/// </summary>
		/// <param name="handle">The channel handle.</param>
		internal Equalizer(Handle handle)
		{
			this.handle = handle;
		}

		/// <summary>
		/// Sets the equalizer values according to frequencies.
		/// </summary>
		/// <param name="equalizer">Dictionary with equalizer frequencies and values.</param>
		public void SetEqualizer(IDictionary<Int32, Double> equalizer)
		{
		}

		/// <summary>
		/// Sets the equalizer value according to frequency.
		/// </summary>
		/// <param name="frequency"></param>
		/// <param name="value"></param>
		public void SetEqualizerFrequency(Int32 frequency, Double value)
		{
		}

		/// <summary>
		/// Gets the equalizer values according to frequencies.
		/// </summary>
		/// <returns>Dictionary with equalizer frequencies and values.</returns>
		public IDictionary<Int32, Double> GetEqualizer() => equalizer.ToDictionary(pair => pair.Key.Item2, pair => pair.Value);

	}
}