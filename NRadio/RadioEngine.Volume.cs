using System;
using Dartware.NRadio.BassWrapper;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{
		
		/// <summary>
		/// Contains volume level.
		/// </summary>
		private Double volume;

		/// <summary>
		/// Gets or sets the volume level. Values in the range from 0 to 100 are allowed.
		/// </summary>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		public Double Volume
		{
			get
			{

				if (!isPlaying)
				{
					return volume;
				}

				return GetVolume();

			}
			set
			{

				if (value < 0 || value > 100)
				{
					throw new ArgumentOutOfRangeException(nameof(value), "The value must be between 0 and 100.");
				}

				volume = value;

				if (isPlaying)
				{
					SetVolume(value);
				}

			}
		}

		/// <summary>
		/// Sets the volume level.
		/// </summary>
		/// <param name="volume">Volume level.</param>
		private void SetVolume(Double volume)
		{
			Bass.BASS_ChannelSetAttribute(handle, BASSAttribute.BASS_ATTRIB_VOL, (Single) (volume / 100));
		}

		/// <summary>
		/// Gets the current volume level.
		/// </summary>
		/// <returns>Current volume level.</returns>
		private Double GetVolume()
		{

			Single volume = 0f;

			if (Bass.BASS_ChannelGetAttribute(handle, BASSAttribute.BASS_ATTRIB_VOL, ref volume))
			{
				volume *= 100;
			}

			return volume;

		}

	}
}