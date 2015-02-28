namespace XLabs.Platform
{
	/// <summary>
	/// Class VectorExtensions.
	/// </summary>
	public static class VectorExtensions
	{
		/// <summary>
		/// Ases the vector3.
		/// </summary>
		/// <param name="reading">The reading.</param>
		/// <returns>Vector3.</returns>
		public static Vector3 AsVector3(this Microsoft.Xna.Framework.Vector3 reading)
		{
			return new Vector3(reading.X, reading.Y, reading.Z);
		}
	}
}