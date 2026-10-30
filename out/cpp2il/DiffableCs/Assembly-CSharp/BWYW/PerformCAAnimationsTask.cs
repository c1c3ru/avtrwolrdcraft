namespace BWYW;

public class PerformCAAnimationsTask : DailyTaskBase
{
	[SerializeField]
	private List<String> _animationsNames; //Field offset: 0x40
	[SerializeField]
	private LevelType _level; //Field offset: 0x48
	[SerializeField]
	private string _parentLabel; //Field offset: 0x50
	[SerializeField]
	private bool _ignoreExtraData; //Field offset: 0x58

	public List<String> AnimationsNames
	{
		 get { } //Length: 8
	}

	public bool IgnoreExtraData
	{
		 get { } //Length: 8
	}

	public LevelType Level
	{
		 get { } //Length: 8
	}

	public string ParentLabel
	{
		 get { } //Length: 8
	}

	public PerformCAAnimationsTask() { }

	public List<String> get_AnimationsNames() { }

	public bool get_IgnoreExtraData() { }

	public LevelType get_Level() { }

	public string get_ParentLabel() { }

}

