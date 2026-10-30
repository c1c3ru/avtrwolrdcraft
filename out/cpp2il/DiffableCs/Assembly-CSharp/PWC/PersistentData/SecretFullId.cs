namespace PWC.PersistentData;

public class SecretFullId : IEquatable<SecretFullId>
{
	public int secretId; //Field offset: 0x10
	public LevelType secretLeveType; //Field offset: 0x14

	public SecretFullId(int secretId, LevelType secretLeveType) { }

	public SecretFullId(string fullIdString) { }

	public override bool Equals(SecretFullId other) { }

	public static string GetFullId(int id, LevelType leveType) { }

	public virtual int GetHashCode() { }

	public virtual string ToString() { }

}

