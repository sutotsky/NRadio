using System;
using System.Collections.Generic;
using System.Linq;
using Un4seen.Bass;
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
		/// Contains a dictionary with equalizer frequencies and values.
		/// </summary>
		private readonly IDictionary<Int32, EqualizerValue> values;

		/// <summary>
		/// Initializes a new instance of the <see cref="Equalizer"/> class.
		/// </summary>
		/// <param name="handle">The channel handle.</param>
		internal Equalizer(Handle handle)
		{
			this.handle = handle;
			values = new Dictionary<Int32, EqualizerValue>();
		}

		/// <summary>
		/// Sets the equalizer values according to frequencies.
		/// </summary>
		/// <param name="equalizer">Dictionary with equalizer frequencies and values.</param>
		/// <exception cref="ArgumentNullException"></exception>
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

			EqualizerValue equalizerValue = new EqualizerValue(frequency, value);
			BASS_DX8_PARAMEQ parameqDX8 = new BASS_DX8_PARAMEQ();
			
			if (values.ContainsKey(frequency))
			{

				Handle eqValueHandle = values[frequency]?.Handle;

				if (eqValueHandle != null)
				{
					Bass.BASS_ChannelRemoveFX(handle, eqValueHandle);
				}

			}

			Int32 fxHandle = Bass.BASS_ChannelSetFX(handle, BASSFXType.BASS_FX_DX8_PARAMEQ, frequency);

			equalizerValue.Handle = new Handle(fxHandle);

			parameqDX8.fCenter = (Single) frequency;
			parameqDX8.fGain = (Single) value;
			parameqDX8.fBandwidth = 8f;

			Bass.BASS_FXSetParameters(equalizerValue.Handle, parameqDX8);

			values[frequency] = equalizerValue;

		}

		/// <summary>
		/// Gets the equalizer values according to frequencies.
		/// </summary>
		/// <returns>Dictionary with equalizer frequencies and values.</returns>
		public IDictionary<Int32, Double> GetEqualizer() => values.ToDictionary(pair => pair.Value.Frequency, pair => pair.Value.Value);

	}
}