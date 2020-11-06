using System;

namespace Dartware.NRadio
{
	/// <summary>
	/// The connection state.
	/// </summary>
	public enum ConnectionState : Int32
	{
		/// <summary>
		/// None.
		/// </summary>
		None = 0,
		/// <summary>
		/// Connection.
		/// </summary>
		Connection = 1,
		/// <summary>
		/// Connection error.
		/// </summary>
		ConnectionError = 2,
		/// <summary>
		/// Buffering.
		/// </summary>
		Buffering = 3
	}
}