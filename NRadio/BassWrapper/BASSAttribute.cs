namespace Dartware.NRadio.BassWrapper
{
    /// <summary>
    /// Channel attribute options used by BASS_ChannelSetAttribute(Int32, BASSAttribute, Single) and BASS_ChannelGetAttribute(Int32, BASSAttribute, Single).
    /// </summary>
	internal enum BASSAttribute
	{
        /// <summary>
        /// The sample rate of a channel. 0 = original rate (when the channel was created).
        /// </summary>
        BASS_ATTRIB_FREQ = 1,
        /// <summary>
        /// The volume level of a channel. 0 (silent) to 1 (full). This can go above 1.0 for amplification.
        /// </summary>
        BASS_ATTRIB_VOL = 2,
        /// <summary>
        /// The panning/balance position of a channel. -1 (full left) to +1 (full right), 0 = centre.
        /// </summary>
        BASS_ATTRIB_PAN = 3,
        /// <summary>
        /// The wet (reverb) / dry (no reverb) mix ratio on a sample, stream, or MOD music channel with 3D functionality. 0 (full dry) to 1 (full wet), -1 = automatically calculate the mix based on the distance (the default).
        /// </summary>
        BASS_ATTRIB_EAXMIX = 4,
        /// <summary>
        /// Non-Windows: Disable playback buffering? 0 = no, else yes.
        /// </summary>
        BASS_ATTRIB_NOBUFFER = 5,
        /// <summary>
        /// The CPU usage of a channel (in percentage).
        /// </summary>
        BASS_ATTRIB_CPU = 7,
        /// <summary>
        /// The sample rate conversion quality of a channel. 0 = linear interpolation, 1 = 8 point sinc interpolation, 2 = 16 point sinc interpolation, 3 = 32 point sinc interpolation. Other values are also accepted but will be interpreted as 0 or 3, depending on whether they are lower or higher.
        /// </summary>
        BASS_ATTRIB_SRC = 8,
        /// <summary>
        /// The download buffer level required to resume stalled playback. The resumption level in percent. 0 - 100 (the default is 50%).
        /// </summary>
        BASS_ATTRIB_NET_RESUME = 9,
        /// <summary>
        /// The scanned info of a channel.
        /// </summary>
        BASS_ATTRIB_SCANINFO = 10,
        /// <summary>
        /// Disable Playback ramping? 0 = no, else yes.
        /// </summary>
        BASS_ATTRIB_NORAMP = 11,
        /// <summary>
        /// Gets the average bitrate (bkps). The bitrate in kilobits per second.
        /// </summary>
        BASS_ATTRIB_BITRATE = 12,
        /// <summary>
        /// Playback buffering length. 0 = no buffering. This is automatically capped to the full length of the channel's playback buffer.
        /// </summary>
        BASS_ATTRIB_BUFFER = 13,
        /// <summary>
        /// The amplification level of a MOD music. 0 (min) to 100 (max). This will be rounded down to a whole number.
        /// </summary>
        BASS_ATTRIB_MUSIC_AMPLIFY = 256,
        /// <summary>
        /// The pan separation level of a MOD music. 0 (min) to 100 (max), 50 = linear. This will be rounded down to a whole number.
        /// </summary>
        BASS_ATTRIB_MUSIC_PANSEP = 257,
        /// <summary>
        /// The position scaler of a MOD music. 1 (min) to 256 (max). This will be rounded down to a whole number.
        /// </summary>
        BASS_ATTRIB_MUSIC_PSCALER = 258,
        /// <summary>
        /// The BPM of a MOD music. 1 (min) to 255 (max). This will be rounded down to a whole number.
        /// </summary>
        BASS_ATTRIB_MUSIC_BPM = 259,
        /// <summary>
        /// The speed of a MOD music. 0 (min) to 255 (max). This will be rounded down to a whole number.
        /// </summary>
        BASS_ATTRIB_MUSIC_SPEED = 260,
        /// <summary>
        /// The global volume level of a MOD music. 0 (min) to 64 (max, 128 for IT format). This will be rounded down to a whole number.
        /// </summary>
        BASS_ATTRIB_MUSIC_VOL_GLOBAL = 261,
        /// <summary>
        /// The number of active channels in a MOD music.
        /// </summary>
        BASS_ATTRIB_MUSIC_ACTIVE = 262,
        /// <summary>
        /// The volume level of a channel in a MOD music + channel#. 0 (silent) to 1 (full).
        /// </summary>
        BASS_ATTRIB_MUSIC_VOL_CHAN = 512,
        /// <summary>
        /// The volume level of an instrument in a MOD music + inst#. 0 (silent) to 1 (full).
        /// </summary>
        BASS_ATTRIB_MUSIC_VOL_INST = 768,
        /// <summary>
        /// BASS_FX Tempo: The Tempo in percents (-95%..0..+5000%).
        /// </summary>
        BASS_ATTRIB_TEMPO = 65536,
        /// <summary>
        /// BASS_FX Tempo: The Pitch in semitones (-60..0..+60).
        /// </summary>
        BASS_ATTRIB_TEMPO_PITCH = 65537,
        /// <summary>
        /// BASS_FX Tempo: The Samplerate in Hz, but calculates by the same % as BASS_ATTRIB_TEMPO.
        /// </summary>
        BASS_ATTRIB_TEMPO_FREQ = 65538,
        /// <summary>
        /// BASS_FX Tempo Option: Use FIR low-pass (anti-alias) filter (gain speed, lose quality)? true = 1 (default), false = 0. On iOS, Android, WinCE and Linux ARM platforms this is by default disabled for lower CPU usage.
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_USE_AA_FILTER = 65552,
        /// <summary>
        /// BASS_FX Tempo Option: FIR low-pass (anti-alias) filter length in taps (8 .. 128 taps, default = 32, should be %4).
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_AA_FILTER_LENGTH = 65553,
        /// <summary>
        /// BASS_FX Tempo Option: Use quicker tempo change algorithm (gain speed, lose quality)? true =1, false =0 (default).
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_USE_QUICKALGO = 65554,
        /// <summary>
        /// BASS_FX Tempo Option: Tempo Sequence in milliseconds (default = 82).
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_SEQUENCE_MS = 65555,
        /// <summary>
        /// BASS_FX Tempo Option: SeekWindow in milliseconds (default = 14).
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_SEEKWINDOW_MS = 65556,
        /// <summary>
        /// BASS_FX Tempo Option: Tempo Overlap in milliseconds (default = 12).
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_OVERLAP_MS = 65557,
        /// <summary>
        /// BASS_FX Tempo Option: Prevents clicks with tempo changes (default = FALSE).
        /// </summary>
        BASS_ATTRIB_TEMPO_OPTION_PREVENT_CLICK = 65558,
        /// <summary>
        /// BASS_FX Reverse: The Playback direction (-1=BASS_FX_RVS_REVERSE or 1=BASS_FX_RVS_FORWARD).
        /// </summary>
        BASS_ATTRIB_REVERSE_DIR = 69632,
        /// <summary>
        /// BASSMIDI: Gets the Pulses Per Quarter Note (or ticks per beat) value of the MIDI file.
        /// </summary>
        BASS_ATTRIB_MIDI_PPQN = 73728,
        /// <summary>
        /// BASSMIDI: The maximum percentage of CPU time that a MIDI stream can use. 0 to 100, 0 = unlimited.
        /// </summary>
        BASS_ATTRIB_MIDI_CPU = 73729,
        /// <summary>
        /// BASSMIDI: The number of MIDI channels in a MIDI stream. 1 (min) - 128 (max). For a MIDI file stream, the minimum is 16.
        /// </summary>
        BASS_ATTRIB_MIDI_CHANS = 73730,
        /// <summary>
        /// BASSMIDI: The maximum number of samples to play at a time (polyphony) in a MIDI stream. 1 (min) - 1000 (max).
        /// </summary>
        BASS_ATTRIB_MIDI_VOICES = 73731,
        /// <summary>
        /// BASSMIDI: The number of samples currently playing in a MIDI stream.
        /// </summary>
        BASS_ATTRIB_MIDI_VOICES_ACTIVE = 73732,
        /// <summary>
        /// BASSMIDI: The current state of a MIDI stream (2nd overload).
        /// </summary>
        BASS_ATTRIB_MIDI_STATE = 73733,
        /// <summary>
        /// BASSMIDI: The sample rate conversion quality of a MIDI stream's samples. 0 = linear interpolation, 1 = 8 point sinc interpolation, 2 = 16 point sinc interpolation.
        /// </summary>
        BASS_ATTRIB_MIDI_SRC = 73734,
        /// <summary>
        /// BASSMIDI: Disable killed note fading? 0 = killed note fading enabled (default), 1 = killed note fading disabled.
        /// </summary>
        BASS_ATTRIB_MIDI_KILL = 73735,
        /// <summary>
        /// BASSMIDI: The volume level of a track in a MIDI file stream + track#. track#: The track to set the volume of... 0 = first track. volume: The volume level (0.0=silent, 1.0=normal/default).
        /// </summary>
        BASS_ATTRIB_MIDI_TRACK_VOL = 73984,
        /// <summary>
        /// BASSOPUS: The sample rate of an Opus stream's source material.
        /// </summary>
        BASS_ATTRIB_OPUS_ORIGFREQ = 77824,
        /// <summary>
        /// BASSdsd: The gain applied when converting to PCM.
        /// </summary>
        BASS_ATTRIB_DSD_GAIN = 81920,
        /// <summary>
        /// BASSdsd: The DSD sample rate.
        /// </summary>
        BASS_ATTRIB_DSD_RATE = 81921,
        /// <summary>
        /// BASSmix: Custom output latency.
        /// </summary>
        BASS_ATTRIB_MIXER_LATENCY = 86016,
        /// <summary>
        /// BASSmix: Amount of data to asynchronously buffer from a splitter's source. The amount to buffer, in seconds... 0 = disable asynchronous buffering. The asynchronous buffering will be limited to the splitter's buffer length, as determined by BASS_CONFIG_SPLIT_BUFFER.
        /// </summary>
        BASS_ATTRIB_SPLIT_ASYNCBUFFER = 86032,
        /// <summary>
        /// BASSmix: Maximum amount of data to asynchronously buffer at a time from a splitter's source. The maximum amount to data to asynchronously buffer at a time from the source, in seconds... 0 = as much as possible.
        /// </summary>
        BASS_ATTRIB_SPLIT_ASYNCPERIOD = 86033,
        /// <summary>
        /// The active track number. handle: The WebM stream handle. track: The track number. 1 = first.
        /// </summary>
        BASS_ATTRIB_WEBM_TRACK = 90112,
        /// <summary>
        /// Slide the attribute's value logarthmically rather than linearly. This cannot be used when going from positive to negative or vice versa. An exception is when using a negative value with BASS_ATTRIB_VOL to fade-out and stop.
        /// </summary>
        BASS_SLIDE_LOG = 16777216
    }
}