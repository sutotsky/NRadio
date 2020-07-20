namespace Dartware.NRadio.BassWrapper
{
	/// <summary>
	/// <see cref="Bass.BASS_ChannelIsActive(System.Int32)"/> return values.
	/// </summary>
	internal enum BASSActive
	{
		/// <summary>
		/// The channel is not active, or handle is not a valid channel.
		/// </summary>
		BASS_ACTIVE_STOPPED,
		/// <summary>
		/// The channel is playing (or recording).
		/// </summary>
		BASS_ACTIVE_PLAYING,
		/// <summary>
		/// Playback of the stream has been stalled due to there not being enough sample data to continue playing. The playback will automatically resume once there's sufficient data to do so.
		/// </summary>
		BASS_ACTIVE_STALLED,
		/// <summary>
		/// The channel is paused.
		/// </summary>
		BASS_ACTIVE_PAUSED,
		/// <summary>
		/// The channel's device is paused.
		/// </summary>
		BASS_ACTIVE_PAUSED_DEVICE
	}
}