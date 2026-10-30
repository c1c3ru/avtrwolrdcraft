namespace ExtraAnimations;

public class ExtendedAnimationsMap : ScriptableObject
{
	[SerializeField]
	private List<CAAnimationsExtensions> _extensionsList; //Field offset: 0x18
	[SerializeField]
	private List<LevelCAItemHandlerData> _extraCAItemHendlerDataList; //Field offset: 0x20

	public List<CAAnimationsExtensions> ExtensionsList
	{
		 get { } //Length: 8
	}

	public List<LevelCAItemHandlerData> ExtraCAItemHendlerDataList
	{
		 get { } //Length: 8
	}

	public ExtendedAnimationsMap() { }

	public List<CAAnimationsExtensions> get_ExtensionsList() { }

	public List<LevelCAItemHandlerData> get_ExtraCAItemHendlerDataList() { }

}

