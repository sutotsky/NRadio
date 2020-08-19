using System;

namespace Dartware.NRadio.Core
{
	/// <summary>
	/// Represents channel handle. A HSTREAM, HMUSIC, or HRECORD.
	/// </summary>
	internal sealed class Handle
	{

		/// <summary>
		/// The channel handle.
		/// </summary>
		private Int32 handle;

		/// <summary>
		/// Returns <see langword="true"/> if handle is null, otherwise <see langword="false"/>.
		/// </summary>
		internal Boolean IsNull => handle == 0;

		/// <summary>
		/// Initializes a new instance of the <see cref="Handle"/> class.
		/// </summary>
		internal Handle()
		{
			handle = 0;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="Handle"/> class.
		/// </summary>
		/// <param name="handle">Channel handle.</param>
		internal Handle(Int32 handle)
		{
			this.handle = handle;
		}

		/// <summary>
		/// Sets the handle
		/// </summary>
		/// <param name="handle">Channel handle.</param>
		internal void SetHandle(Int32 handle)
		{
			this.handle = handle;
		}

		/// <summary>
		/// Returns current handle value.
		/// </summary>
		/// <param name="handle">Instance of the <see cref="Handle"/> class.</param>
		public static implicit operator Int32(Handle handle) => handle.handle;

		/// <summary>
		/// Returns <see langword="true"/> if handle is not null, otherwise <see langword="false"/>.
		/// </summary>
		/// <param name="handle">Instance of the <see cref="Handle"/> class.</param>
		public static implicit operator Boolean(Handle handle) => !handle.IsNull;

	}
}