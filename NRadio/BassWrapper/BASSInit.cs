using System;

namespace Dartware.NRadio.BassWrapper
{
    /// <summary>
    /// Initialization flags to be used with BASS_Init(Int32, Int32, BASSInit, IntPtr, IntPtr).
    /// </summary>
	[Flags]
	public enum BASSInit
	{
        /// <summary>
        /// 0 = 16 bit, stereo, no 3D, no Latency calc, no Speaker Assignments.
        /// </summary>
        BASS_DEVICE_DEFAULT = 0,
        /// <summary>
        /// Use 8 bit resolution, else 16 bit.
        /// </summary>
        BASS_DEVICE_8BITS = 1,
        /// <summary>
        /// Use mono, else stereo.
        /// </summary>
        BASS_DEVICE_MONO = 2,
        /// <summary>
        /// Enable 3D functionality. If the BASS_DEVICE_3D flag is not specified when initilizing BASS, then the 3D flags (BASS_SAMPLE_3D and BASS_MUSIC_3D) are ignored when loading/creating a sample/stream/music.
        /// </summary>
        BASS_DEVICE_3D = 4,
        /// <summary>
        /// Calculate device latency.
        /// </summary>
        BASS_DEVICE_LATENCY = 256,
        /// <summary>
        /// Use the Windows control panel setting to detect the number of speakers. Only use this option if BASS doesn't detect the correct number of supported speakers automatically and you want to force BASS to use the number of speakers as configured in the windows control panel.
        /// </summary>
        BASS_DEVICE_CPSPEAKERS = 1024,
        /// <summary>
        /// Force enabling of speaker assignment (always 8 speakers will be used regardless if the soundcard supports them). Only use this option if BASS doesn't detect the correct number of supported speakers automatically and you want to force BASS to use 8 speakers.
        /// </summary>
        BASS_DEVICE_SPEAKERS = 2048,
        /// <summary>
        /// Ignore speaker arrangement.
        /// </summary>
        BASS_DEVICE_NOSPEAKER = 4096,
        /// <summary>
        /// Linux-only: Initialize the device using the ALSA "dmix" plugin, else initialize the device for exclusive access.
        /// </summary>
        BASS_DEVIDE_DMIX = 8192,
        /// <summary>
        /// Set the device's output rate to freq, otherwise leave it as it is.
        /// </summary>
        BASS_DEVICE_FREQ = 16384,
        /// <summary>
        /// Limits the output to stereo (only really affects Linux; it's ignored on Windows and OSX).
        /// </summary>
        BASS_DEVICE_STEREO = 32768,
        /// <summary>
        /// Use hog/exclusive mode.
        /// </summary>
        BASS_DEVICE_HOG = 65536,
        /// <summary>
        /// Use DirectSound output.
        /// </summary>
        BASS_DEVICE_DSOUND = 262144
    }
}