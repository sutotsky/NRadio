using System;
using Dartware.NRadio.Core;

namespace Dartware.NRadio.FX
{
	/// <summary>
	/// Represents the equalizer value.
	/// </summary>
	internal sealed class EqualizerValue
	{

		/// <summary>
		/// Gets the equalizer frequency.
		/// </summary>
		internal Int32 Frequency { get; }

		/// <summary>
		/// Gets the equalizer value.
		/// </summary>
		internal Double Value { get; }

		/// <summary>
		/// Gets or sets equalizer value handle.
		/// </summary>
		internal Handle Handle { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="EqualizerValue"/> class.
		/// </summary>
		/// <param name="frequency">Equalizer frequency</param>
		/// <param name="value">Equalizer value.</param>
		internal EqualizerValue(Int32 frequency, Double value)
		{
			Frequency = frequency;
			Value = value;
		}

	}
}