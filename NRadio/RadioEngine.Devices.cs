using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Un4seen.Bass;

namespace Dartware.NRadio
{
	internal sealed partial class RadioEngine
	{

		/// <summary>
		/// Cancellation token source for default device wacher.
		/// </summary>
		private CancellationTokenSource defaultDeviceWacherCancellationTokenSource;

		/// <summary>
		/// Stores a value that indicates need to audo detect default system audio device.
		/// </summary>
		private Boolean autoDetectAudioDevice;

		/// <summary>
		/// Gets all available output devices.
		/// </summary>
		public IEnumerable<IDevice> Devices => GetAvailableDevices();

		/// <summary>
		/// Gets the system default output device.
		/// </summary>
		public IDevice SystemDefaultDevice => Devices.FirstOrDefault(device => device.IsDefault);

		/// <summary>
		/// Gets the current output device.
		/// </summary>
		public IDevice CurrentDevice { get; private set; }

		/// <summary>
		/// Gets or sets a value that indicates need to audo detect default system audio device.
		/// </summary>
		public Boolean AutoDetectAudioDevice
		{
			get => autoDetectAudioDevice;
			set
			{

				if (value == autoDetectAudioDevice)
				{
					return;
				}
				
				autoDetectAudioDevice = value;

				if (value)
				{

					defaultDeviceWacherCancellationTokenSource?.Cancel();

					defaultDeviceWacherCancellationTokenSource = new CancellationTokenSource();

					StartDefaultDeviceWatching(defaultDeviceWacherCancellationTokenSource.Token);

				}
				else
				{
					defaultDeviceWacherCancellationTokenSource?.Cancel();
				}

			}
		}

		/// <summary>
		/// Occurs when output device changed.
		/// </summary>
		public event Action<IDevice> DeviceChanged;

		/// <summary>
		/// Sets the current output device.
		/// </summary>
		/// <param name="device">Output device.</param>
		public void SetDevice(IDevice device)
		{

			if (device == null)
			{
				throw new ArgumentNullException(nameof(device), "Device cannot be null.");
			}

			if (device.Equals(CurrentDevice))
			{
				return;
			}

			CurrentDevice = device;

			DeviceChanged?.Invoke(device);

			if (!String.IsNullOrEmpty(url))
			{

				Boolean continuePlaying = isPlaying;

				SetURL(url);

				if (continuePlaying)
				{
					Play();
				}

			}

		}

		/// <summary>
		/// Sets the current output device.
		/// </summary>
		/// <param name="device">Output device.</param>
		public async Task SetDeviceAsync(IDevice device)
		{
			await Task.Run(() => SetDevice(device));
		}

		/// <summary>
		/// Starts the watch default system output device.
		/// </summary>
		/// <param name="cancellationToken">Cancellatio token.</param>
		private void StartDefaultDeviceWatching(CancellationToken cancellationToken)
		{
			Task.Run(() =>
			{
				while (!cancellationToken.IsCancellationRequested)
				{

					IDevice defaultSystemDevice = SystemDefaultDevice;

					if (defaultSystemDevice != null)
					{
						if (!defaultSystemDevice.Equals(CurrentDevice) && AutoDetectAudioDevice)
						{
							SetDevice(defaultSystemDevice);
						}
					}

					Thread.Sleep(500);

				}
			});
		}

		/// <summary>
		/// Returns all available output devices.
		/// </summary>
		/// <returns>Collection of available output devices.</returns>
		private IEnumerable<IDevice> GetAvailableDevices()
		{
			
			BASS_DEVICEINFO[] deviceInfos = Bass.BASS_GetDeviceInfos();
			IEnumerable<IDevice> devices = deviceInfos.Select((deviceInfo, index) => new Device(deviceInfo.name, (DeviceType) deviceInfo.type, deviceInfo.driver, deviceInfo.IsDefault, deviceInfo.IsEnabled, index));

			return devices;

		}

	}
}