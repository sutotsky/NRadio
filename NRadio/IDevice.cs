using System;

namespace Dartware.NRadio
{
	/// <summary>
	/// Defines functionality for stores output device info.
	/// </summary>
	public interface IDevice
	{

		/// <summary>
		/// Gets the device name.
		/// </summary>
		String Name { get; }

		/// <summary>
		/// Gets the type of audio device.
		/// </summary>
		DeviceType Type { get; }

		/// <summary>
		/// Device driver identifier.
		/// </summary>
		String Driver { get; }

		/// <summary>
		/// The device is the system default device.
		/// </summary>
		Boolean IsDefault { get; }

		/// <summary>
		/// The device is enable and can be used.
		/// </summary>
		Boolean IsEnabled { get; }

	}
}