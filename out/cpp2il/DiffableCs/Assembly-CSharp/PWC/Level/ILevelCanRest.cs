namespace PWC.Level;

public interface ILevelCanRest
{

	public event Action<LevelAvatarRestAreaBase> OnBeginDropOnRestAreaAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public event Action<LevelAvatarRestAreaBase> OnEndDropOnRestAreaAction
	{
		[CompilerGenerated]
		 add { } //Length: 0
		[CompilerGenerated]
		 remove { } //Length: 0
	}

	public LevelAvatarRestAreaBase CurrentRestArea
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	[CompilerGenerated]
	public void add_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public void add_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	public LevelAvatarRestAreaBase get_CurrentRestArea() { }

	public LevelItem GetLevelItem() { }

	public void ReleaseCurrentRestAreaIfExists() { }

	[CompilerGenerated]
	public void remove_OnBeginDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	[CompilerGenerated]
	public void remove_OnEndDropOnRestAreaAction(Action<LevelAvatarRestAreaBase> value) { }

	public void set_CurrentRestArea(LevelAvatarRestAreaBase value) { }

}

