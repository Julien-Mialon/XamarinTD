using System.Text;
using PCLCrypto;

namespace Helpers
{
	public static class HashHelper
	{
		public static string Hash(string password)
		{
			IHashAlgorithmProvider hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha1);
			byte[] data = Encoding.UTF8.GetBytes(password);
			byte[] hashed = hasher.HashData(data);

			StringBuilder builder = new StringBuilder();
			foreach (byte b in hashed)
			{
				string part = string.Format("{0:X}", b);
				for (int i = part.Length; i < 2; ++i)
				{
					builder.Append("0");
				}
				builder.Append(part);
			}

			return builder.ToString().ToLowerInvariant();
		}
	}
}
