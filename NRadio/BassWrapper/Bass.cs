using System;
using System.Runtime.InteropServices;

namespace Dartware.NRadio.BassWrapper
{
	/// <summary>
	/// API wrapper for bass.dll. Requires: bass.dll - Bass Audio Library - available <see href="http://www.un4seen.com">here</see>.
	/// </summary>
	internal static class Bass
	{

		/// <summary>
		/// Initializes an output device.
		/// </summary>
		/// <param name="device">The device to use... -1 = default device, 0 = no sound, 1 = first real output device. BASS_GetDeviceInfo(Int32, BASS_DEVICEINFO) or BASS_GetDeviceCount() can be used to get the total number of devices.</param>
		/// <param name="freq">Output sample rate.</param>
		/// <param name="flags">Any combination of these flags (see <see cref="BASSInit"/>).</param>
		/// <param name="win">The application's main window... Zero = the desktop window (use this for console applications).</param>
		/// <returns></returns>
		internal static Boolean BASS_Init(Int32 device, Int32 freq, BASSInit flags, IntPtr win) => BASS_Init(device, freq, flags, win, IntPtr.Zero);

		/// <summary>
		/// Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plugin supported file on the internet, optionally receiving the downloaded data in a callback.
		/// </summary>
		/// <param name="url">URL of the file to stream. Should begin with "http://", "https://" or "ftp://", or another add-on supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and each header should be terminated with a carriage return and line feed ("\r\n").</param>
		/// <param name="offset">File position to start streaming from. This is ignored by some servers, specifically when the file length is unknown, for example a Shout/Icecast server.</param>
		/// <param name="flags">Any combination of these flags (see <see cref="BASSFlag"/>).</param>
		/// <param name="proc">Callback function to receive the file as it is downloaded... null = no callback.</param>
		/// <param name="user">User instance data to pass to the callback function.</param>
		/// <returns>If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		internal static Int32 BASS_StreamCreateURL(String url, Int32 offset, BASSFlag flags, DOWNLOADPROC proc, IntPtr user)
		{

			flags |= BASSFlag.BASS_UNICODE;

			Int32 stream = BASS_StreamCreateURLUnicode(url, offset, flags, proc, user);

			if (stream == 0)
			{

				flags &= BASSFlag.BASS_SPEAKER_PAIR15 | BASSFlag.BASS_SAMPLE_OVER_DIST | BASSFlag.BASS_AC3_DOWNMIX_DOLBY | BASSFlag.BASS_SAMPLE_8BITS | BASSFlag.BASS_SAMPLE_MONO | BASSFlag.BASS_SAMPLE_LOOP | BASSFlag.BASS_SAMPLE_3D | BASSFlag.BASS_SAMPLE_SOFTWARE | BASSFlag.BASS_SAMPLE_MUTEMAX | BASSFlag.BASS_SAMPLE_VAM | BASSFlag.BASS_SAMPLE_FX | BASSFlag.BASS_SAMPLE_FLOAT | BASSFlag.BASS_RECORD_PAUSE | BASSFlag.BASS_RECORD_ECHOCANCEL | BASSFlag.BASS_RECORD_AGC | BASSFlag.BASS_STREAM_AUTOFREE | BASSFlag.BASS_STREAM_RESTRATE | BASSFlag.BASS_STREAM_BLOCK | BASSFlag.BASS_STREAM_DECODE | BASSFlag.BASS_STREAM_STATUS | BASSFlag.BASS_SPEAKER_LEFT | BASSFlag.BASS_SPEAKER_RIGHT | BASSFlag.BASS_ASYNCFILE | BASSFlag.BASS_WV_STEREO | BASSFlag.BASS_AC3_DYNAMIC_RANGE | BASSFlag.BASS_AAC_FRAME960;
				
				stream = BASS_StreamCreateURLAscii(url, offset, flags, proc, user);

			}

			return stream;

		}

		/// <summary>
		/// Starts (or resumes) playback of a sample, stream, MOD music, or recording.
		/// </summary>
		/// <param name="handle">The channel handle... a HCHANNEL / HMUSIC / HSTREAM / HRECORD handle.</param>
		/// <param name="restart">Restart playback from the beginning? If handle is a user stream, it's current buffer contents are flushed. If it's a MOD music, it's BPM/etc are automatically reset to their initial values.</param>
		/// <returns>If successful, true is returned, else false is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_ChannelPlay(Int32 handle, [MarshalAs(UnmanagedType.Bool)] Boolean restart);

		/// <summary>
		/// Sets the value of an attribute of a sample, stream or MOD music.
		/// </summary>
		/// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM or HRECORD.</param>
		/// <param name="attrib">The attribute to set the value of <see cref="BASSAttribute"/>.</param>
		/// <param name="value">The new attribute value. See the attribute's documentation for details on the possible values.</param>
		/// <returns>If successful, true is returned, else false is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_ChannelSetAttribute(Int32 handle, BASSAttribute attrib, Single value);

		/// <summary>
		/// Retrieves the value of an attribute of a sample, stream or MOD music. Can also get the sample rate of a recording channel.
		/// </summary>
		/// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM or HRECORD.</param>
		/// <param name="attrib">The attribute to set the value of <see cref="BASSAttribute"/>.</param>
		/// <param name="value">Pointer to a variable to receive the attribute value.</param>
		/// <returns>If successful, true is returned, else false is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_ChannelGetAttribute(Int32 handle, BASSAttribute attrib, ref Single value);

		/// <summary>
		/// Frees all resources used by the output device, including all it's samples, streams, and MOD musics.
		/// </summary>
		/// <returns>If successful, then true is returned, else false is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_Free();

		/// <summary>
		/// Frees a sample stream's resources, including any SYNC/DSP/FX it has.
		/// </summary>
		/// <param name="handle">The stream handle.</param>
		/// <returns>If successful, true is returned, else false is returned. Use <see cref="BASS_ErrorGetCode"/> to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_StreamFree(Int32 handle);

		/// <summary>
		/// Stops the output, stopping all musics/samples/streams.
		/// </summary>
		/// <returns>If successful, then true is returned, else false is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_Stop();

		/// <summary>
		/// Stops a sample, stream, MOD music, or recording.
		/// </summary>
		/// <param name="handle">The channel handle... a HCHANNEL, HMUSIC, HSTREAM or HRECORD handle.</param>
		/// <returns>If successful, true is returned, else false is returned. Use BASS_ErrorGetCode() to get the error code.</returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern Boolean BASS_ChannelStop(Int32 handle);

		/// <summary>
		/// Retrieves the error code for the most recent BASS function call in the current thread.
		/// </summary>
		/// <returns>If no error occured during the last BASS function call then <see cref="BASSError.BASS_OK"/> is returned, else one of the <see cref="BASSError"/> values is returned. See the function description for an explanation of what the error code means.</returns>
		[DllImport("bass")]
		internal static extern BASSError BASS_ErrorGetCode();

		/// <summary>
		/// Initializes an output device.
		/// </summary>
		/// <param name="device">The device to use... -1 = default device, 0 = no sound, 1 = first real output device. BASS_GetDeviceInfo can be used to enumerate the available devices.</param>
		/// <param name="freq">Output sample rate.</param>
		/// <param name="flags">A combination of <see cref="BASSInit"/> flags.</param>
		/// <param name="win">The application's main window... 0 = the desktop window (use this for console applications). This is only needed when using DirectSound output.</param>
		/// <param name="clsid">Class identifier of the object to create, that will be used to initialize DirectSound... NULL = use default.</param>
		/// <returns></returns>
		[DllImport("bass")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern Boolean BASS_Init(Int32 device, Int32 freq, BASSInit flags, IntPtr win, IntPtr clsid);

		/// <summary>
		/// Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plugin supported file on the internet, optionally receiving the downloaded data in a callback function.
		/// </summary>
		/// <param name="url">URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and each header should be terminated with a carriage return and line feed ("\r\n").</param>
		/// <param name="offset">File position to start streaming from. This is ignored by some servers, specifically when the length is unknown/undefined.</param>
		/// <param name="flags">A combination of <see cref="BASSFlag"/> flags.</param>
		/// <param name="proc">Callback function to receive the file as it is downloaded... NULL = no callback.</param>
		/// <param name="user">User instance data to pass to the callback function.</param>
		/// <returns>If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error code.</returns>
		[DllImport("bass", EntryPoint = "BASS_StreamCreateURL")]
		private static extern Int32 BASS_StreamCreateURLUnicode([MarshalAs(UnmanagedType.LPWStr), In] String url, Int32 offset, BASSFlag flags, DOWNLOADPROC proc, IntPtr user);

		/// <summary>
		/// Creates a sample stream from an MP3, MP2, MP1, OGG, WAV, AIFF or plugin supported file on the internet, optionally receiving the downloaded data in a callback function.
		/// </summary>
		/// <param name="url">URL of the file to stream. Should begin with "http://" or "https://" or "ftp://", or another add-on supported protocol. The URL can be followed by custom HTTP request headers to be sent to the server; the URL and each header should be terminated with a carriage return and line feed ("\r\n").</param>
		/// <param name="offset">File position to start streaming from. This is ignored by some servers, specifically when the length is unknown/undefined.</param>
		/// <param name="flags">A combination of <see cref="BASSFlag"/> flags.</param>
		/// <param name="proc">Callback function to receive the file as it is downloaded... NULL = no callback.</param>
		/// <param name="user">User instance data to pass to the callback function.</param>
		/// <returns>If successful, the new stream's handle is returned, else 0 is returned. Use BASS_ErrorGetCode to get the error code.</returns>
		[DllImport("bass", EntryPoint = "BASS_StreamCreateURL", CharSet = CharSet.Ansi)]
		private static extern Int32 BASS_StreamCreateURLAscii([MarshalAs(UnmanagedType.LPStr), In] String url, Int32 offset, BASSFlag flags, DOWNLOADPROC proc, IntPtr user);

	}
}