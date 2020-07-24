using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dartware.NRadio
{
	/// <summary>
	/// Defines the functionality for working with streaming audio, based on third-party URLs.
	/// </summary>
	public interface IRadioEngine
	{

		/// <summary>
		/// Gets or sets the volume level. Values in the range from 0 to 100 are allowed.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		Double Volume { get; set; }

		/// <summary>
		/// Gets the current metadata.
		/// </summary>
		IMetadata Metadata { get; }

		/// <summary>
		/// Gets all available output devices.
		/// </summary>
		IEnumerable<IDevice> Devices { get; }

		/// <summary>
		/// Gets the system default output device.
		/// </summary>
		IDevice SystemDefaultDevice { get; }

		/// <summary>
		/// Gets the current output device.
		/// </summary>
		IDevice CurrentDevice { get; }

		/// <summary>
		/// Gets or sets a value that indicates need to audo detect default system audio device.
		/// </summary>
		Boolean AutoDetectAudioDevice { get; set; }

		/// <summary>
		/// Occurs when connection is started.
		/// </summary>
		event Action ConnectionStarted;

		/// <summary>
		/// Occurs when connection is ended.
		/// </summary>
		event Action ConnectionEnded;

		/// <summary>
		/// Occurs when buffering is started.
		/// </summary>
		event Action BufferingStarted;

		/// <summary>
		/// Occurs when buffering progress is changed.
		/// </summary>
		event Action<Int64> BufferingProgressChanged;

		/// <summary>
		/// Occurs when buffering is ended.
		/// </summary>
		event Action BufferingEnded;

		/// <summary>
		/// Occurs when metadata changed.
		/// </summary>
		event Action<IMetadata> MetadataChanged;

		/// <summary>
		/// Occurs when output device changed.
		/// </summary>
		event Action<IDevice> DeviceChanged;

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		void SetURL(String url);

		/// <summary>
		/// Sets the stream URL.
		/// </summary>
		/// <param name="url">Stream URL.</param>
		Task SetURLAsync(String url);

		/// <summary>
		/// Returns current URL of the stream.
		/// </summary>
		/// <returns>URL of the stream.</returns>
		String GetURL();

		/// <summary>
		/// Starts playing.
		/// </summary>
		void Play();

		/// <summary>
		/// Pause playing.
		/// </summary>
		void Pause();

		/// <summary>
		/// Sets the current output device.
		/// </summary>
		/// <param name="device">Output device.</param>
		void SetDevice(IDevice device);

		/// <summary>
		/// Sets the current output device.
		/// </summary>
		/// <param name="device">Output device.</param>
		Task SetDeviceAsync(IDevice device);

	}
}