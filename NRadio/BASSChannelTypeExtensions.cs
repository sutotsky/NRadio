using Un4seen.Bass;

namespace Dartware.NRadio
{
	/// <summary>
	/// Extensions for <see cref="Un4seen.Bass.BASSChannelType"/> enum.
	/// </summary>
	internal static class BASSChannelTypeExtensions
	{
		/// <summary>
		/// Transforms <see cref="Un4seen.Bass.BASSChannelType"/> value to <see cref="Dartware.NRadio.Format"/> value.
		/// </summary>
		/// <param name="channelType"><see cref="Un4seen.Bass.BASSChannelType"/> value.</param>
		/// <returns><see cref="Dartware.NRadio.Format"/> value.</returns>
		internal static Format ToFormat(this BASSChannelType channelType)
		{
			return channelType switch
			{
				BASSChannelType.BASS_CTYPE_MUSIC_MO3 => Format.MO3,
				BASSChannelType.BASS_CTYPE_STREAM_OGG => Format.OGG,
				BASSChannelType.BASS_CTYPE_STREAM_MP1 => Format.MP1,
				BASSChannelType.BASS_CTYPE_STREAM_MP2 => Format.MP2,
				BASSChannelType.BASS_CTYPE_STREAM_MP3 => Format.MP3,
				BASSChannelType.BASS_CTYPE_STREAM_AIFF => Format.AIFF,
				BASSChannelType.BASS_CTYPE_STREAM_CA => Format.CoreAudio,
				BASSChannelType.BASS_CTYPE_STREAM_MF => Format.AAC,
				BASSChannelType.BASS_CTYPE_STREAM_CD => Format.CDA,
				BASSChannelType.BASS_CTYPE_STREAM_WMA => Format.WMA,
				BASSChannelType.BASS_CTYPE_STREAM_OFR => Format.OFR,
				BASSChannelType.BASS_CTYPE_STREAM_APE => Format.APE,
				BASSChannelType.BASS_CTYPE_STREAM_FLAC => Format.FLAC,
				BASSChannelType.BASS_CTYPE_STREAM_MPC => Format.MPC,
				BASSChannelType.BASS_CTYPE_STREAM_AAC => Format.AAC,
				BASSChannelType.BASS_CTYPE_STREAM_MP4 => Format.MP4,
				BASSChannelType.BASS_CTYPE_STREAM_SPX => Format.SPX,
				BASSChannelType.BASS_CTYPE_STREAM_MIDI => Format.MIDI,
				BASSChannelType.BASS_CTYPE_STREAM_ALAC => Format.ALAC,
				BASSChannelType.BASS_CTYPE_STREAM_TTA => Format.TTA,
				BASSChannelType.BASS_CTYPE_STREAM_AC3 => Format.AC3,
				BASSChannelType.BASS_CTYPE_STREAM_OPUS => Format.OPUS,
				BASSChannelType.BASS_CTYPE_STREAM_ADX => Format.ADX,
				BASSChannelType.BASS_CTYPE_STREAM_AIX => Format.AIX,
				BASSChannelType.BASS_CTYPE_MUSIC_MOD => Format.MOD,
				BASSChannelType.BASS_CTYPE_MUSIC_MTM => Format.MTM,
				BASSChannelType.BASS_CTYPE_MUSIC_S3M => Format.S3M,
				BASSChannelType.BASS_CTYPE_MUSIC_XM => Format.XM,
				BASSChannelType.BASS_CTYPE_MUSIC_IT => Format.IT,
				BASSChannelType.BASS_CTYPE_STREAM_WAV => Format.WAV,
				BASSChannelType.BASS_CTYPE_STREAM_WAV_PCM => Format.WAV,
				BASSChannelType.BASS_CTYPE_STREAM_WAV_FLOAT => Format.WAV,
				BASSChannelType.BASS_CTYPE_SAMPLE => Format.Unknown,
				BASSChannelType.BASS_CTYPE_STREAM => Format.Unknown,
				BASSChannelType.BASS_CTYPE_RECORD => Format.Unknown,
				_ => Format.Unknown,
			};
		}
	}
}