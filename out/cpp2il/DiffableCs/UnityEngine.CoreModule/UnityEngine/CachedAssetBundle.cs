namespace UnityEngine;

[UsedByNativeCode]
public struct CachedAssetBundle
{
	private string m_Name; //Field offset: 0x0
	private Hash128 m_Hash; //Field offset: 0x8

	public Hash128 hash
	{
		 get { } //Length: 12
	}

	public string name
	{
		 get { } //Length: 8
	}

	public CachedAssetBundle(string name, Hash128 hash) { }

	public Hash128 get_hash() { }

	public string get_name() { }

}

