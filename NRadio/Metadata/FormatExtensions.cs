using System;

namespace Dartware.NRadio.Meta
{
	/// <summary>
	/// Extension methods for <see cref="Format"/> enumerable.
	/// </summary>
	internal static class FormatExtensions
	{
		/// <summary>
		/// Returns format extension string.
		/// </summary>
		/// <param name="format">Formst.</param>
		/// <returns>Format extension string.</returns>
		internal static String ToExtension(this Format format)
		{
			return format switch
			{
				Format.MO3 => "mo3",
				Format.OGG => "ogg",
				Format.MP1 => "mp1",
				Format.MP2 => "mp2",
				Format.MP3 => "mp3",
				Format.AIFF => "aiff",
				Format.CoreAudio => "ca",
				Format.MediaFoundation => "aac",
				Format.CDA => "cda",
				Format.WMA => "wma",
				Format.OFR => "ofr",
				Format.APE => "ape",
				Format.FLAC => "flac",
				Format.MPC => "mpc",
				Format.AAC => "aac",
				Format.MP4 => "mp4",
				Format.SPX => "spx",
				Format.MIDI => "midi",
				Format.ALAC => "alac",
				Format.TTA => "tta",
				Format.AC3 => "ac3",
				Format.OPUS => "opus",
				Format.ADX => "adx",
				Format.AIX => "aix",
				Format.MOD => "mod",
				Format.MTM => "mtm",
				Format.S3M => "s3m",
				Format.XM => "xm",
				Format.IT => "it",
				Format.WAV => "wav",
				Format.Unknown => null,
				_ => null,
			};
		}
	}
}