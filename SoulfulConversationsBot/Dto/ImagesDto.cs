using SoulfulConversationsBot.Enums;

namespace SoulfulConversationsBot.Dto
{
	/// <summary>
	/// Images dto.
	/// </summary>
	public class ImagesDto
	{
		#region Public Fields

		/// <summary>
		/// Images.
		/// </summary>
		public Dictionary<string, string>? Images { get; set; }

		#endregion

		#region Indexers

		/// <summary>
		/// Index for getting image.
		/// </summary>
		/// <param name="key">Image key.</param>
		/// <returns>Image.</returns>
		public string this[Image key]
		{
			get
			{
				return Images![key.ToString()];
			}
		}

		#endregion
	}
}
