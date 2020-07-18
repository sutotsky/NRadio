using System;

namespace Dartware.NRadio.BassWrapper
{
	/// <summary>
	/// Internet stream download callback function.
	/// </summary>
	/// <param name="buffer">The pointer to the buffer containing the downloaded data.</param>
	/// <param name="length">The number of bytes in the buffer... 0 = HTTP or ICY tags.</param>
	/// <param name="user">The user instance data given when <see cref="Bass.BASS_StreamCreateURL(String, Int32, BASSFlag, DOWNLOADPROC, IntPtr)" /> was called.</param>
	internal delegate void DOWNLOADPROC(IntPtr buffer, Int32 length, IntPtr user);
}