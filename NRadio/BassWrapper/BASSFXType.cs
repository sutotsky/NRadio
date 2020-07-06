using System;

namespace Dartware.NRadio.BassWrapper
{
    /// <summary>
    /// FX effect types, use with BASS_ChannelSetFX(Int32, BASSFXType, Int32).
    /// </summary>
	public enum BASSFXType
	{
        /// <summary>
        /// DX8 Chorus. Use BASS_DX8_CHORUS structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_CHORUS = 0,
        /// <summary>
        /// DX8 Compressor. Use BASS_DX8_COMPRESSOR structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_COMPRESSOR = 1,
        /// <summary>
        /// DX8 Distortion. Use BASS_DX8_DISTORTION structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_DISTORTION = 2,
        /// <summary>
        /// DX8 Echo. Use BASS_DX8_ECHO structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_ECHO = 3,
        /// <summary>
        /// DX8 Flanger. Use BASS_DX8_FLANGER structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_FLANGER = 4,
        /// <summary>
        /// DX8 Gargle. Use BASS_DX8_GARGLE structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_GARGLE = 5,
        /// <summary>
        /// DX8 I3DL2 (Interactive 3D Audio Level 2) reverb. Use BASS_DX8_I3DL2REVERB structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_I3DL2REVERB = 6,
        /// <summary>
        /// DX8 Parametric equalizer. Use BASS_DX8_PARAMEQ structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_PARAMEQ = 7,
        /// <summary>
        /// DX8 Reverb. Use BASS_DX8_REVERB structure to set/get parameters.
        /// </summary>
        BASS_FX_DX8_REVERB = 8,
        /// <summary>
        /// Volume level adjustment. Use BASS_FX_VOLUME_PARAM structure to set/get parameters.
        /// </summary>
        BASS_FX_VOLUME = 9,
        /// <summary>
        /// BASS_FX Channel Volume Ping-Pong (multi channel). Use BASS_BFX_ROTATE structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_ROTATE = 65536,
        /// <summary>
        /// BASS_FX Echo (2 channels max). Use BASS_BFX_ECHO structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_ECHO4 instead.")]
        BASS_FX_BFX_ECHO = 65537,
        /// <summary>
        /// BASS_FX Flanger (multi channel). Use BASS_BFX_FLANGER structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_CHORUS instead.")]
        BASS_FX_BFX_FLANGER = 65538,
        /// <summary>
        /// BASS_FX Volume control (multi channel). Use BASS_BFX_VOLUME structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_VOLUME = 65539,
        /// <summary>
        /// BASS_FX Peaking Equalizer (multi channel). Use BASS_BFX_PEAKEQ structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_PEAKEQ = 65540,
        /// <summary>
        /// BASS_FX Reverb (2 channels max). Use BASS_BFX_REVERB structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_FREEVERB instead.")]
        BASS_FX_BFX_REVERB = 65541,
        /// <summary>
        /// BASS_FX Low Pass Filter (multi channel). Use BASS_BFX_LPF structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use 2x BASS_FX_BFX_BQF with BASS_BFX_BQF_LOWPASS filter and appropriate fQ values instead.")]
        BASS_FX_BFX_LPF = 65542,
        /// <summary>
        /// BASS_FX Channel Swap/Remap/Downmix (multi channel). Use BASS_BFX_MIX structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_MIX = 65543,
        /// <summary>
        /// BASS_FX Dynamic Amplification (multi channel). Use BASS_BFX_DAMP structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_DAMP = 65544,
        /// <summary>
        /// BASS_FX Auto WAH (multi channel). Use BASS_BFX_AUTOWAH structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_AUTOWAH = 65545,
        /// <summary>
        /// BASS_FX Echo 2 (multi channel). Use BASS_BFX_ECHO2 structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_ECHO4 instead.")]
        BASS_FX_BFX_ECHO2 = 65546,
        /// <summary>
        /// BASS_FX Phaser (multi channel). Use BASS_BFX_PHASER structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_PHASER = 65547,
        /// <summary>
        /// BASS_FX Echo 3 (multi channel). Use BASS_BFX_ECHO3 structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_ECHO4 instead.")]
        BASS_FX_BFX_ECHO3 = 65548,
        /// <summary>
        /// BASS_FX Chorus (multi channel). Use BASS_BFX_CHORUS structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_CHORUS = 65549,
        /// <summary>
        /// BASS_FX All Pass Filter (multi channel). Use BASS_BFX_APF structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_BQF with BASS_BFX_BQF_ALLPASS filter instead.")]
        BASS_FX_BFX_APF = 65550,
        /// <summary>
        /// BASS_FX Dynamic Range Compressor (multi channel). Use BASS_BFX_COMPRESSOR structure to set/get parameters.
        /// </summary>
        [Obsolete("This effect is obsolete; use BASS_FX_BFX_COMPRESSOR2 instead.")]
        BASS_FX_BFX_COMPRESSOR = 65551,
        /// <summary>
        /// BASS_FX Distortion (multi channel). Use BASS_BFX_DISTORTION structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_DISTORTION = 65552,
        /// <summary>
        /// BASS_FX Dynamic Range Compressor (multi channel). Use BASS_BFX_COMPRESSOR2 structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_COMPRESSOR2 = 65553,
        /// <summary>
        /// BASS_FX Volume Envelope (multi channel). Use BASS_BFX_VOLUME_ENV structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_VOLUME_ENV = 65554,
        /// <summary>
        /// BASS_FX BiQuad filters (multi channel). Use BASS_BFX_BQF structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_BQF = 65555,
        /// <summary>
        /// BASS_FX Echo/Reverb 4 (multi channel). Use BASS_BFX_ECHO4 structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_ECHO4 = 65556,
        /// <summary>
        /// BASS_FX Pitch Shift using FFT (multi channel). Use BASS_BFX_PITCHSHIFT structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_PITCHSHIFT = 65557,
        /// <summary>
        /// BASS_FX Pitch Shift using FFT (multi channel). Use BASS_BFX_FREEVERB structure to set/get parameters.
        /// </summary>
        BASS_FX_BFX_FREEVERB = 65558
    }
}