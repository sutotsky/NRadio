using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dartware.NRadio.Devices;
using Dartware.NRadio.FX;
using Dartware.NRadio.Meta;

namespace Dartware.NRadio
{
	/// <summary>
	/// Defines the functionality for working with streaming audio, based on third-party URLs.
	/// </summary>
	public interface IRadioEngine
	{

		/// <summary>
		/// Gets the current URL.
		/// </summary>
		String URL { get; }

		/// <summary>
		/// Gets or sets the volume level. Values in the range from 0 to 100 are allowed.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		Double Volume { get; set; }

		/// <summary>
		/// Contains flag which indicates whether playback is in progress.
		/// </summary>
		PlaybackStatus PlaybackStatus { get; }

		/// <summary>
		/// The recording is started.
		/// </summary>
		Boolean IsRecording { get; }

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
		/// Gets or sets the recording path.
		/// </summary>
		String RecordingPath { get; set; }

		/// <summary>
		/// <see langword="true"/> if necessary splitting by track while recording, otherwise <see langword="false"/>.
		/// </summary>
		Boolean SplitByTrackWhileRecording { get; set; }

		/// <summary>
		/// An effect that adjusts the timbre of an audio signal by changing the amplitude of its frequency components.
		/// </summary>
		IEqualizer Equalizer { get; }

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

		/// <summary>
		/// Start recording.
		/// </summary>
		void StartRecording();

		/// <summary>
		/// Stop recording.
		/// </summary>
		void StopRecording();

	}
}