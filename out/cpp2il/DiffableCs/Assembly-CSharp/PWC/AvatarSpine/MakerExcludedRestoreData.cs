namespace PWC.AvatarSpine;

public class MakerExcludedRestoreData
{
	public readonly Dictionary<SpineType, HashSet`1<String>> _dict; //Field offset: 0x10

	public int Count
	{
		 get { } //Length: 80
	}

	public IReadOnlyDictionary<SpineType, HashSet`1<String>> Dict
	{
		 get { } //Length: 8
	}

	public MakerExcludedRestoreData() { }

	public void Add(SpineType spineType, string skinName) { }

	public int get_Count() { }

	public IReadOnlyDictionary<SpineType, HashSet`1<String>> get_Dict() { }

	public bool Remove(SpineType spineType, string skinName) { }

}

