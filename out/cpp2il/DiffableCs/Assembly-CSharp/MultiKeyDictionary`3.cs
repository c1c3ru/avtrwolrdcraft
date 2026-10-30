//Type is in global namespace

[DefaultMember("Item")]
public class MultiKeyDictionary : Dictionary<T1, Dictionary`2<T2, T3>>
{

	public Dictionary<T2, T3> Item
	{
		 get { } //Length: 180
	}

	public MultiKeyDictionary`3() { }

	public bool ContainsKey(T1 key1, T2 key2) { }

	public Dictionary<T2, T3> get_Item(T1 key) { }

}

