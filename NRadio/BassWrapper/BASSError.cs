namespace Dartware.NRadio.BassWrapper
{
    /// <summary>
    /// BASS error codes as returned e.g. by <see cref="Bass.BASS_ErrorGetCode"/>.
    /// </summary>
	internal enum BASSError
	{
        /// <summary>
        /// Some other mystery error.
        /// </summary>
        BASS_ERROR_UNKNOWN = -1,
        /// <summary>
        /// All is OK.
        /// </summary>
        BASS_OK = 0,
        /// <summary>
        /// Memory error.
        /// </summary>
        BASS_ERROR_MEM = 1,
        /// <summary>
        /// Can't open the file.
        /// </summary>
        BASS_ERROR_FILEOPEN = 2,
        /// <summary>
        /// Can't find a free/valid driver.
        /// </summary>
        BASS_ERROR_DRIVER = 3,
        /// <summary>
        /// The sample buffer was lost.
        /// </summary>
        BASS_ERROR_BUFLOST = 4,
        /// <summary>
        /// Invalid handle.
        /// </summary>
        BASS_ERROR_HANDLE = 5,
        /// <summary>
        /// Unsupported sample format.
        /// </summary>
        BASS_ERROR_FORMAT = 6,
        /// <summary>
        /// Invalid playback position.
        /// </summary>
        BASS_ERROR_POSITION = 7,
        /// <summary>
        /// BASS_Init has not been successfully called.
        /// </summary>
        BASS_ERROR_INIT = 8,
        /// <summary>
        /// BASS_Start has not been successfully called.
        /// </summary>
        BASS_ERROR_START = 9,
        /// <summary>
        /// No CD in drive.
        /// </summary>
        BASS_ERROR_NOCD = 12,
        /// <summary>
        /// Invalid track number.
        /// </summary>
        BASS_ERROR_CDTRACK = 13,
        /// <summary>
        /// Already initialized/paused/whatever.
        /// </summary>
        BASS_ERROR_ALREADY = 14,
        /// <summary>
        /// Not paused.
        /// </summary>
        BASS_ERROR_NOPAUSE = 16,
        /// <summary>
        /// Not an audio track.
        /// </summary>
        BASS_ERROR_NOTAUDIO = 17,
        /// <summary>
        /// Can't get a free channel.
        /// </summary>
        BASS_ERROR_NOCHAN = 18,
        /// <summary>
        /// An illegal type was specified.
        /// </summary>
        BASS_ERROR_ILLTYPE = 19,
        /// <summary>
        /// An illegal parameter was specified.
        /// </summary>
        BASS_ERROR_ILLPARAM = 20,
        /// <summary>
        /// No 3D support.
        /// </summary>
        BASS_ERROR_NO3D = 21,
        /// <summary>
        /// No EAX support.
        /// </summary>
        BASS_ERROR_NOEAX = 22,
        /// <summary>
        /// Illegal device number.
        /// </summary>
        BASS_ERROR_DEVICE = 23,
        /// <summary>
        /// Not playing.
        /// </summary>
        BASS_ERROR_NOPLAY = 24,
        /// <summary>
        /// Illegal sample rate.
        /// </summary>
        BASS_ERROR_FREQ = 25,
        /// <summary>
        /// The stream is not a file stream.
        /// </summary>
        BASS_ERROR_NOTFILE = 27,
        /// <summary>
        /// No hardware voices available.
        /// </summary>
        BASS_ERROR_NOHW = 29,
        /// <summary>
        /// The MOD music has no sequence data.
        /// </summary>
        BASS_ERROR_EMPTY = 31,
        /// <summary>
        /// No internet connection could be opened.
        /// </summary>
        BASS_ERROR_NONET = 32,
        /// <summary>
        /// Couldn't create the file.
        /// </summary>
        BASS_ERROR_CREATE = 33,
        /// <summary>
        /// Effects are not available.
        /// </summary>
        BASS_ERROR_NOFX = 34,
        /// <summary>
        /// The channel is playing.
        /// </summary>
        BASS_ERROR_PLAYING = 35,
        /// <summary>
        /// Requested data is not available.
        /// </summary>
        BASS_ERROR_NOTAVAIL = 37,
        /// <summary>
        /// The channel is a "decoding channel".
        /// </summary>
        BASS_ERROR_DECODE = 38,
        /// <summary>
        /// A sufficient DirectX version is not installed.
        /// </summary>
        BASS_ERROR_DX = 39,
        /// <summary>
        /// Connection timeout.
        /// </summary>
        BASS_ERROR_TIMEOUT = 40,
        /// <summary>
        /// Unsupported file format.
        /// </summary>
        BASS_ERROR_FILEFORM = 41,
        /// <summary>
        /// Unavailable speaker.
        /// </summary>
        BASS_ERROR_SPEAKER = 42,
        /// <summary>
        /// Invalid BASS version (used by add-ons).
        /// </summary>
        BASS_ERROR_VERSION = 43,
        /// <summary>
        /// Codec is not available/supported.
        /// </summary>
        BASS_ERROR_CODEC = 44,
        /// <summary>
        /// The channel/file has ended.
        /// </summary>
        BASS_ERROR_ENDED = 45,
        /// <summary>
        /// The device is busy (eg. in "exclusive" use by another process).
        /// </summary>
        BASS_ERROR_BUSY = 46,
        /// <summary>
        /// BassWma: the file is protected.
        /// </summary>
        BASS_ERROR_WMA_LICENSE = 1000,
        /// <summary>
        /// BassWma: WM9 is required.
        /// </summary>
        BASS_ERROR_WMA_WM9 = 1001,
        /// <summary>
        /// BassWma: access denied (user/pass is invalid).
        /// </summary>
        BASS_ERROR_WMA_DENIED = 1002,
        /// <summary>
        /// BassWma: no appropriate codec is installed.
        /// </summary>
        BASS_ERROR_WMA_CODEC = 1003,
        /// <summary>
        /// BassWma: individualization is needed.
        /// </summary>
        BASS_ERROR_WMA_INDIVIDUAL = 1004,
        /// <summary>
        /// BassEnc: ACM codec selection cancelled.
        /// </summary>
        BASS_ERROR_ACM_CANCEL = 2000,
        /// <summary>
        /// BassEnc: Access denied (invalid password).
        /// </summary>
        BASS_ERROR_CAST_DENIED = 2100,
        /// <summary>
        /// BassVst: the given effect has no inputs and is probably a VST instrument and no effect.
        /// </summary>
        BASS_VST_ERROR_NOINPUTS = 3000,
        /// <summary>
        /// BassVst: the given effect has no outputs.
        /// </summary>
        BASS_VST_ERROR_NOOUTPUTS = 3001,
        /// <summary>
        /// BassVst: the given effect does not support realtime processing.
        /// </summary>
        BASS_VST_ERROR_NOREALTIME = 3002,
        /// <summary>
        /// BASSWASAPI: no WASAPI available.
        /// </summary>
        BASS_ERROR_WASAPI = 5000,
        BASS_ERROR_WASAPI_BUFFER = 5001,
        BASS_ERROR_WASAPI_CATEGORY = 5002,
        /// <summary>
        /// BASS_AAC: non-streamable due to MP4 atom order ('mdat' before 'moov').
        /// </summary>
        BASS_ERROR_MP4_NOSTREAM = 6000,
        BASS_ERROR_WEBM_NOTAUDIO = 8000,
        BASS_ERROR_WEBM_TRACK = 8001
    }
}