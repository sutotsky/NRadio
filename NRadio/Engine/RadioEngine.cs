using System;
using System.Collections.Concurrent;
using System.Threading;
using Un4seen.Bass;
using Dartware.NRadio.FX;
using Dartware.NRadio.Core;
using Dartware.NRadio.Devices;

namespace Dartware.NRadio
{
	/// <summary>
	/// Radio-engine implementation based on the cross-platform library bass.dll. Requires: bass.dll - Bass Audio Library - available <see href="http://www.un4seen.com">here</see>.
	/// </summary>
	internal sealed partial class RadioEngine : IRadioEngine
	{

		/// <summary>
		/// Sampling frequency.
		/// </summary>
		private const Int32 SAMPLING_FREQUENCY = 44100;

		/// <summary>
		/// The channel handle.
		/// </summary>
		private readonly Handle handle;

		/// <summary>
		/// Initializes a new instance of the <see cref="RadioEngine"/> class.
		/// </summary>
		internal RadioEngine()
		{
			handle = new Handle();
			volume = 100;
			urlsStack = new ConcurrentStack<String>();
			CurrentDevice = SystemDefaultDevice;
			AutoDetectAudioDevice = true;
			RecordingPath = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
			SplitByTrackWhileRecording = false;
			Equalizer = new Equalizer(handle);
		}

		/// <summary>
		/// Initialize engine.
		/// </summary>
		private void Init()
		{
			
			Bass.BASS_Init((CurrentDevice as Device).Handle, SAMPLING_FREQUENCY, BASSInit.BASS_DEVICE_DEFAULT, IntPtr.Zero);

			bufferingCancellationTokenSource = new CancellationTokenSource();
			metadataCancellationTokenSource = new CancellationTokenSource();
			recordingCancellationTokenSource = new CancellationTokenSource();

		}

		/// <summary>
		/// Frees all resources used by the output device, including stream by handle.
		/// </summary>
		private void Free()
		{
			
			bufferingCancellationTokenSource?.Cancel();
			metadataCancellationTokenSource?.Cancel();

			StopRecording();

			MetadataChanged?.Invoke(Meta.Metadata.Empty);

			Metadata = Meta.Metadata.Empty;
			
			Pause();
			Bass.BASS_ChannelStop(handle);
			Bass.BASS_Stop();

			Bass.BASS_StreamFree(handle);
			Bass.BASS_Free();

		}

	}
}