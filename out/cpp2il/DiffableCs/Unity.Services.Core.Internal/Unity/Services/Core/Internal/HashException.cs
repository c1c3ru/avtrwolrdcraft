namespace Unity.Services.Core.Internal;

internal class HashException : Exception
{
	[CompilerGenerated]
	private readonly int <Hash>k__BackingField; //Field offset: 0x8C

	public int Hash
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public HashException(int hash) { }

	public HashException(int hash, string message) { }

	public HashException(int hash, string message, Exception inner) { }

	[CompilerGenerated]
	public int get_Hash() { }

}

