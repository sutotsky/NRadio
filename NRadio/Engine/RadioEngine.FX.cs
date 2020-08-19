using Dartware.NRadio.FX;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{
		/// <summary>
		/// An effect that adjusts the timbre of an audio signal by changing the amplitude of its frequency components.
		/// </summary>
		public IEqualizer Equalizer { get; }
	}
}