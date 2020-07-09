namespace Dartware.NRadio
{
	/// <summary>
	/// Provides access to factory properties and methods for creating and configuring <see cref="IRadioEngine"/> implementation instances.
	/// </summary>
	public sealed class RadioEngineFactory
	{
		/// <summary>
		/// Gets the default <see cref="IRadioEngine"/> implementation instance for this factory.
		/// </summary>
		public static IRadioEngine Engine => new RadioEngine();
	}
}