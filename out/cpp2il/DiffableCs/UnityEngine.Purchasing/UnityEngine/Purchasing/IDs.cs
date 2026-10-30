namespace UnityEngine.Purchasing;

public class IDs : IEnumerable<KeyValuePair`2<String, String>>, IEnumerable
{
	private readonly Dictionary<String, String> m_Dic; //Field offset: 0x10

	public IDs() { }

	public void Add(string id, String[] stores) { }

	public void Add(string id, Object[] stores) { }

	public override IEnumerator<KeyValuePair`2<String, String>> GetEnumerator() { }

	internal string SpecificIDForStore(string store, string defaultValue) { }

	private override IEnumerator System.Collections.IEnumerable.GetEnumerator() { }

}

