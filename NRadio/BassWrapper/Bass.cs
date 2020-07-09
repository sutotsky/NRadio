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
		/// <param name="flags">Any combination of these flags (see <see cref="BASSInit"/>)</param>
		/// <param name="win">The application's main window... Zero = the desktop window (use this for console applications).</param>
		/// <returns></returns>
		public static Boolean BASS_Init(Int32 device, Int32 freq, BASSInit flags, IntPtr win) => BASS_Init(device, freq, flags, win, IntPtr.Zero);

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

	}
}