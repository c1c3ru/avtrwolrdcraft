namespace UnityEngine;

[NativeHeader("Runtime/Misc/Cache.h")]
[StaticAccessor("CacheWrapper", StaticAccessorType::DoubleColon (2))]
public struct Cache : IEquatable<Cache>
{
	private int m_Handle; //Field offset: 0x0

	public int expirationDelay
	{
		 set { } //Length: 68
	}

	internal int handle
	{
		internal get { } //Length: 8
	}

	public long maximumAvailableStorageSpace
	{
		 set { } //Length: 68
	}

	public string path
	{
		 get { } //Length: 60
	}

	public bool valid
	{
		 get { } //Length: 60
	}

	[NativeThrows]
	internal static string Cache_GetPath(int handle) { }

	internal static bool Cache_IsValid(int handle) { }

	[NativeThrows]
	internal static void Cache_SetExpirationDelay(int handle, int value) { }

	[NativeThrows]
	internal static void Cache_SetMaximumDiskSpaceAvailable(int handle, long value) { }

	public virtual bool Equals(object other) { }

	public override bool Equals(Cache other) { }

	internal int get_handle() { }

	public string get_path() { }

	public bool get_valid() { }

	public virtual int GetHashCode() { }

	public void set_expirationDelay(int value) { }

	public void set_maximumAvailableStorageSpace(long value) { }

}

