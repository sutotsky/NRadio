namespace Dartware.NRadio.BassWrapper
{
	/// <summary>
	/// Stream File Position modes to be used with <see cref="Bass.BASS_StreamGetFilePosition(System.Int32, BASSStreamFilePosition)"/>.
	/// </summary>
	internal enum BASSStreamFilePosition
	{
		/// <summary>
		/// Position that is to be decoded for playback next. This will be a bit ahead of the position actually being heard due to buffering.
		/// </summary>
		BASS_FILEPOS_CURRENT = 0,
		/// <summary>
		/// Download progress of an internet file stream or "buffered" user file stream.
		/// </summary>
		BASS_FILEPOS_DOWNLOAD = 1,
		/// <summary>
		/// End of the file, in other words the file length. When streaming in blocks, the file length is unknown, so the download buffer length is returned instead.
		/// </summary>
		BASS_FILEPOS_END = 2,
		/// <summary>
		/// Start of stream data in the file.
		/// </summary>
		BASS_FILEPOS_START = 3,
		/// <summary>
		/// Internet file stream or "buffered" user file stream is still connected? 0 = no, 1 = yes.
		/// </summary>
		BASS_FILEPOS_CONNECTED = 4,
		/// <summary>
		/// The amount of data in the buffer of an internet file stream or "buffered" user file stream. Unless streaming in blocks, this is the same as <see cref="BASS_FILEPOS_DOWNLOAD"/>.
		/// </summary>
		BASS_FILEPOS_BUFFER = 5,
		/// <summary>
		/// Returns the socket hanlde used for streaming.
		/// </summary>
		BASS_FILEPOS_SOCKET = 6,
		/// <summary>
		/// The amount of data in the asynchronous file reading buffer. This requires that the BASS_ASYNCFILE flag was used at the stream's creation.
		/// </summary>
		BASS_FILEPOS_ASYNCBUF = 7,
		/// <summary>
		/// Total size of the file.
		/// </summary>
		BASS_FILEPOS_SIZE = 8,
		/// <summary>
		/// The percentage of buffering remaining before playback of an internet file stream or "buffered" user file stream can resume.
		/// </summary>
		BASS_FILEPOS_BUFFERING = 9,
		/// <summary>
		/// WMA add-on: internet buffering progress (0-100%).
		/// </summary>
		BASS_FILEPOS_WMA_BUFFER = 1000,
		/// <summary>
		/// HLS add-on: segment sequence number.
		/// </summary>
		BASS_FILEPOS_HLS_SEGMENT = 65536
    }
}