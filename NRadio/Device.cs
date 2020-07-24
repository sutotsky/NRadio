using System;
using System.Diagnostics.CodeAnalysis;

namespace Dartware.NRadio
{
	/// <summary>
	/// Stores output device info.
	/// </summary>
	internal sealed class Device : IDevice, IEquatable<Device>
	{

		/// <summary>
		/// Gets the device name.
		/// </summary>
		public String Name { get; }

		/// <summary>
		/// Gets the type of audio device.
		/// </summary>
		public DeviceType Type { get; }

		/// <summary>
		/// Device driver identifier.
		/// </summary>
		public String Driver { get; }

		/// <summary>
		/// The device is the system default device.
		/// </summary>
		public Boolean IsDefault { get; }

		/// <summary>
		/// The device is enable and can be used.
		/// </summary>
		public Boolean IsEnabled { get; }

		/// <summary>
		/// Device handle.
		/// </summary>
		internal Int32 Handle { get; }

		/// <summary>
		/// Initializes a new instance of the <see cref="Device"/> class.
		/// </summary>
		private Device()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Device"/> class.
		/// </summary>
		/// <param name="name">Device name.</param>
		/// <param name="type">Audio device type.</param>
		/// <param name="driver">Driver identifier.</param>
		/// <param name="isDefault">Is the system default device.</param>
		/// <param name="isEnabled">Device is enable and can be used.</param>
		/// <param name="handle">Device handle.</param>
		internal Device(String name, DeviceType type, String driver, Boolean isDefault, Boolean isEnabled, Int32 handle)
		{
			Name = name;
			Type = type;
			Driver = driver;
			IsDefault = isDefault;
			IsEnabled = isEnabled;
			Handle = handle;
		}

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="otherDevice">An object to compare with this object.</param>
		/// <returns><see langword="true"/> if the current object is equal to the other parameter; otherwise, <see langword="false"/>.</returns>
		public Boolean Equals([AllowNull] Device otherDevice)
		{

			if (otherDevice == null)
			{
				return false;
			}

			return otherDevice.Name == Name && otherDevice.Type == Type && otherDevice.Driver == Driver;

		}

		/// <summary>
		/// Determines whether the specified object is equal to the current object.
		/// </summary>
		/// <param name="other">The object to compare with the current object.</param>
		/// <returns><see langword="true"/> if the specified object is equal to the current object; otherwise, <see langword="false"/>.</returns>
		public override Boolean Equals(Object other) => Equals(other as Device);

		/// <summary>
		/// Returns a string that represents the current <see cref="Device"/> instance.
		/// </summary>
		/// <returns>A string that represents the current object.</returns>
		public override String ToString() => Name;

		/// <summary>
		/// Serves as the default hash function.
		/// </summary>
		/// <returns>A hash code for the current object.</returns>
		public override Int32 GetHashCode() => base.GetHashCode();

	}
}